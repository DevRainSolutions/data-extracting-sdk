using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


/*
             SOM som = new SOM(3, 10, "Food.csv");
            Console.ReadLine();
 * 
 * Item,protein,carb,fat
Apples,0.4,11.8,0.1
Avocado,1.9,1.9,19.5
Bananas,1.2,23.2,0.3
Beef Steak,20.9,0.0,7.9
Big Mac,13.0,19.0,11.0
Brazil Nuts,15.5,2.9,68.3
Bread,10.5,37.0,3.2
Butter,1.0,0.0,81.0
Cheese,25.0,0.1,34.4
Cheesecake,6.4,28.2,22.7
Cookies,5.7,58.7,29.3
Cornflakes,7.0,84.0,0.9
Eggs,12.5,0.0,10.8
Fried Chicken,17.0,7.0,20.0
Fries,3.0,36.0,13.0
Hot Chocolate,3.8,19.4,10.2
Pepperoni,20.9,5.1,38.3
Pizza,12.5,30.0,11.0
Pork Pie,10.1,27.3,24.2
Potatoes,1.7,16.1,0.3
Rice,6.9,74.0,2.8
Roast Chicken,26.1,0.3,5.8
Sugar,0.0,95.1,0.0
Tuna Steak,25.6,0.0,0.5
Water,0.0,0.0,0.0
 */
namespace DevRain.Data.Mining
{
    public class SelfOrganizingMap
    {
            private Neuron[,] outputs;  // Collection of weights.
            private int iteration;      // Current iteration.
            private int length;        // Side length of output grid.
            private int dimensions;    // Number of input dimensions.
            private Random rnd = new Random();

            private List<string> labels = new List<string>();
            private List<double[]> patterns = new List<double[]>();

            public SelfOrganizingMap(int dimensions, int length, string file)
            {
                this.length = length;
                this.dimensions = dimensions;
                Initialise();
                LoadData(file);
                NormalisePatterns();
                Train(0.0000001);
                DumpCoordinates();
            }

            private void Initialise()
            {
                outputs = new Neuron[length, length];

                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        outputs[i, j] = new Neuron(i, j, length);
                        outputs[i, j].Weights = new double[dimensions];

                        for (int k = 0; k < dimensions; k++)
                        {
                            outputs[i, j].Weights[k] = rnd.NextDouble();
                        }
                    }
                }
            }

            private void LoadData(string file)
            {
                StreamReader reader = File.OpenText(file);
                reader.ReadLine(); // Ignore first line.

                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    labels.Add(line[0]);
                    double[] inputs = new double[dimensions];

                    for (int i = 0; i < dimensions; i++)
                    {
                        inputs[i] = double.Parse(line[i + 1], CultureInfo.GetCultureInfo("en-US"));
                    }
                    patterns.Add(inputs);
                }
                reader.Close();
            }

            private void NormalisePatterns()
            {
                for (int j = 0; j < dimensions; j++)
                {
                    double sum = 0;
                    for (int i = 0; i < patterns.Count; i++)
                    {
                        sum += patterns[i][j];
                    }

                    double average = sum / patterns.Count;

                    for (int i = 0; i < patterns.Count; i++)
                    {
                        patterns[i][j] = patterns[i][j] / average;
                    }
                }
            }

            private void Train(double maxError)
            {
                double currentError = double.MaxValue;

                while (currentError > maxError)
                {
                    currentError = 0;
                    List<double[]> TrainingSet = new List<double[]>();
                    foreach (double[] pattern in patterns)
                    {
                        TrainingSet.Add(pattern);
                    }

                    for (int i = 0; i < patterns.Count; i++)
                    {
                        double[] pattern = TrainingSet[rnd.Next(patterns.Count - i)];
                        currentError += TrainPattern(pattern);
                        TrainingSet.Remove(pattern);
                    }
                    Console.WriteLine(currentError.ToString("0.0000000"));
                }
            }

            private double TrainPattern(double[] pattern)
            {
                double error = 0;
                Neuron winner = Winner(pattern);
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        error += outputs[i, j].UpdateWeights(pattern, winner, iteration);
                    }
                }
                iteration++;
                return Math.Abs(error / (length * length));
            }

            private void DumpCoordinates()
            {
                for (int i = 0; i < patterns.Count; i++)
                {
                    Neuron n = Winner(patterns[i]);
                    Console.WriteLine("{0},{1},{2}", labels[i], n.X, n.Y);
                }
            }

            private Neuron Winner(double[] pattern)
            {
                Neuron winner = null;
                double min = double.MaxValue;

                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                    {
                        double d = Distance(pattern, outputs[i, j].Weights);
                        if (d < min)
                        {
                            min = d;
                            winner = outputs[i, j];
                        }
                    }
                return winner;
            }

            private double Distance(double[] vector1, double[] vector2)
            {
                double value = 0;
                for (int i = 0; i < vector1.Length; i++)
                {
                    value += Math.Pow((vector1[i] - vector2[i]), 2);
                }
                return Math.Sqrt(value);
            }
        }
}
