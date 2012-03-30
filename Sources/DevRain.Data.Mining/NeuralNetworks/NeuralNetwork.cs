// ============================================================================
// <copyright file="ClusterPoint.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Mining
{
    using System;

    // NeuralNetwork.cs
    //
    // Copyright (C) 2004 Kingsley Tagbo 
    //
    // LICENSE:
    // You have my permission to use this software, redistribute it and/or
    // modify it under the terms of the GNU General Public License
    // (SEE HTTP://WWW.FSF.ORG OR THE COPY OF THE GNU PUBLIC LICENSE BELOW)
    // as published by the Free Software Foundation; either version 2
    // of the License, or (at your option) any later version 
    // AS LONG AS YOU INCLUDE A REFERENCE TO KINGSLEY TAGBO - 
    // HTTP://WWW.KDKEYS.NET AS THE ORIGINAL AUTHOR
    // OF THIS PROGRAM AND YOU DO NOT REMOVE THE COPYRIGHT AND LICENSE
    // NOTICES IN THIS FREE SOFTWARE
    //
    // This program is distributed in the hope that it will be useful,
    // but WITHOUT ANY WARRANTY; without even the implied warranty of
    // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    // GNU General Public License for more details.
    //
    // You should have received a copy of the GNU General Public License
    // along with this program; if not, write to the Free Software
    // Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
    //
    //
    //C# ARTIFICIAL NEURAL NETWORK MULTILAYER FEEDFORWARD BACKPROPAGATION ALGORITHM VERSION 1.1
    //DATE		:		DECEMBER 19, 2004 6:42 AM
    //AUTHOR	:		KINGSLEY TAGBO
    //LICENSE	:		DISTRIBUTED UNDER GNU GENERAL PUBLIC LICENSE VERSION 2, JUNE 1991  (SEE WWW.FSF.ORG)
    //			:		YOU CAN ALSO READ THE LICENSE INCLUDED BELOW AFTER THE SOURCE CODE
    //VERSION	:		1.1
    //COPYRIGHT	:		KINGSLEY TAGBO	- HTTP://WWW.KDKEYS.NET
    //RELEASE:	:		GOLD
    //DOCUMENTATION:    http://www.kdkeys.net/ShowForum.aspx?ForumID=1022	

    /// <summary>
    /// Artificial MiultiLayer FeedForward Neural Network With BackPropagation Algorithm
    /// </summary>
    public class NeuralNetwork
    {
        /// <summary>
        /// Static variable for random numbers
        /// </summary>
        static System.Random rand;

        /// <summary>
        /// Static variable for number of neurons or cells in INPUT LAYER 
        /// </summary>
        static int input_count = 3;

        /// <summary>
        /// Static variable for number of neurons or cells in HIDDEN LAYER
        /// </summary>
        static int hidden_count = 2;

        /// <summary>
        /// Static variable for number of neurons or cells in OUTPUT LAYER
        /// </summary>
        static int output_count = 1;

        /// <summary>
        /// Static variable for the number of processing cycles of the Neural Network 
        /// </summary>
        static int iterations = 75;

        /// <summary>
        /// Represents the LEARNING RATE used in gradient descent to 
        /// prevent weights from converging at sub-optimal solutions.
        /// </summary>
        public double learning_rate = 0.8;

        /// <summary>
        /// A two dimensional array of input data from a training sample
        /// An INPUT represented as double [,] inputDataArray = new Double [,] 
        ///	{{0.20, 0.80}, {0.80, 0.4}} would represent 2 training instances
        ///	for an INPUT LAYER with 2 NEURONS or CELLS
        /// </summary>
        public double[,] input_data;

        /// <summary>
        /// A two dimensional array of output data from a training sample
        /// An OUTPUT represented as double [,] outputDataArray = new Double [,] 
        ///	{{0}, {1}} would represent 2 training instances
        ///	for an OUTPUT LAYER with 1 NEURON or CELL
        /// </summary>
        public double[,] output_data;


        /// <summary>
        ///	A collection of neurons representing the input layer
        /// </summary>      
        Neurons input;

        /// <summary>
        /// A collection of neurons representing the hidden layer
        /// </summary>
        Neurons hidden;

        /// <summary>
        /// A collection of neurons representing the output layer
        /// </summary>
        Neurons output;



        /// <summary>
        /// Initializes the LAYERS in the NEURAL NETWORK
        /// </summary>
        /// <param name="inputData">
        /// INPUTS data for the NEURONS in the INPUT LAYER
        /// </param>
        /// <param name="outputData">
        /// OUTPUT data for the NEURONS in the OUTPUT LAYER
        /// </param>
        /// <param name="hidden_layer_count">
        ///	The number of neurons in the HIDDEN LAYER  
        /// </param>                   
        public void Initialize(double[,] inputData, double[,] outputData, int hidden_layer_count)
        {
            this.input_data = inputData;

            input_count = (this.input_data.GetUpperBound(1) + 1);


            hidden_count = hidden_layer_count;


            this.output_data = outputData;

            output_count = (this.output_data.GetUpperBound(1) + 1);




            input = new Neurons();

            for (int i = 0; i < input_count; i++)
            {
                Neuron c = new Neuron(0, i);

                input.Add(c);
            }


            hidden = new Neurons();

            for (int i = 0; i < hidden_count; i++)
            {
                Neuron c = new Neuron(1, i);

                hidden.Add(c);
            }


            output = new Neurons();

            for (int i = 0; i < output_count; i++)
            {
                Neuron c = new Neuron(2, i);

                output.Add(c);
            }
        }


        /// <summary>
        /// Initializes the NEURAL NETWORK with training data input
        /// or a real world data input for classification.
        /// FeedForward feeds the INPUT to the INPUT LAYER neurons
        /// FeedForward feeds the OUTPUT from the INPUT LAYER to the HIDDEN LAYER
        /// FeedForward feeds the OUTPUT from the HIDDEN LAYER to the OUTPUT LAYER
        /// FeedForward uses the Sigmoid Function or Logistic Function to calculate  
        /// the OUTPUT from the INPUT in the HIDDEN and OUTPUT LAYERS
        /// </summary>
        /// <param name="sampleNumber">
        /// A numeric ordered value representing the training or 
        /// classification instance. If the dataset contains 10 
        /// instances or rows, the first row has a sampleNumber = 0
        /// and the last row or instance has a sample number = 9
        /// </param>
        public virtual void FeedForward(int sampleNumber)
        {
            double total;

            Neuron ch = null;

            Neuron ci = null;

            Neuron co = null;


            //feed the input data to the input Neurons layer
            for (int i = 0; i < input.Count; i++)
            {
                ci = input[i];

                ci.Input = this.input_data[sampleNumber, i];
            }


            //feedforward from input to hidden Neurons 
            for (int h = 0; h < hidden.Count; h++)
            {
                total = 0.0;

                ch = hidden[h];

                for (int i = 0; i < input.Count; i++)
                {
                    ci = input[i];

                    total = total + (ci.Output * ch.Weight[i]);
                }

                ch.Input = total + ch.Bias;
            }

            //feedforward from hidden to output Neurons 
            for (int o = 0; o < output.Count; o++)
            {
                total = 0.0;

                co = output[o];

                //feed the expected training result to the output Neurons layer
                co.OutputTraining = this.output_data[sampleNumber, o];

                for (int h = 0; h < hidden.Count; h++)
                {

                    ch = hidden[h];

                    total = total + (ch.Output * co.Weight[h]);
                }

                co.Input = total + co.Bias;
            }

        }


        /// <summary>
        /// Recalculates the BIAS and ERROR in the HIDDEN LAYER
        /// and OUTPUT LAYER. Adjustes the WEIGHTS between the 
        /// OUTPUT LAYER and HIDDEN LAYER and between the HIDDEN
        /// LAYER and the INPUT LAYER using the derivative of
        /// the Sigmoid Function or Logistic Function
        /// </summary>
        public virtual void BackPropagate()
        {
            double total;

            Neuron ch = null;

            Neuron ci = null;

            Neuron co = null;

            //calculate error rate for Output layer 
            for (int o = 0; o < output.Count; o++)
            {
                co = output[o];

                co.Error = co.LogisticFunctionDerivative(co.Output) * (co.OutputTraining - co.Output);
            }

            //error from output to hidden layer
            for (int h = 0; h < hidden.Count; h++)
            {
                total = 0.0;

                ch = hidden[h];

                for (int o = 0; o < output.Count; o++)
                {
                    co = output[o];

                    total = total + (co.Error * co.Weight[o]);
                }

                ch.Error = (ch.LogisticFunction(ch.Output) * total);
            }

            //update all weights in the network 
            //from output Neurons to hidden Neurons 
            for (int o = 0; o < output.Count; o++)
            {
                co = output[o];

                for (int h = 0; h < hidden.Count; h++)
                {

                    ch = hidden[h];

                    co.Weight[h] = co.Weight[h] + (this.learning_rate * co.Error * ch.Output);
                }

                co.Bias = co.Bias + (this.learning_rate * co.Error);
            }


            //update all weights in the network 
            //from hidden Neurons to input Neurons 
            for (int h = 0; h < hidden.Count; h++)
            {
                ch = hidden[h];

                for (int i = 0; i < input.Count; i++)
                {
                    ci = input[i];

                    ch.Weight[i] = ch.Weight[i] + (this.learning_rate * ch.Error * ci.Output);
                }

                ch.Bias = ch.Bias + (this.learning_rate * ch.Error);
            }
        }


        /// <summary> 
        /// Generates random double values between -1.0 and +1.0
        /// </summary> 
        /// <returns>
        /// System.Double data type between -1.0 and +1.0 
        /// </returns> 
        public static double Random
        {
            get
            {
                if (rand == null)
                {
                    rand = new System.Random();
                }

                int MaxLimit = +1000;

                int MinLimit = -1000;

                double number = (double)(rand.Next(MinLimit, MaxLimit)) / 2000;

                return number;
            }
        }


        /// <summary>
        /// Executes a Neural Network MultiLayer FeedForward BackPropagation 
        /// Algorithm for Learning or Classification 
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //a two-dimensional array of 14 samples and 6 input Neurons
            //14 samples with 6 inputs
            double[,] inputDataArray = new Double[,] 
		{	
					{1, 0, 0, 0.85, 0.85, 0}, {1, 0, 0, 0.80, 0.90, 1}, {0, 1, 0, 0.83, 0.86, 0}, {0, 0, 1, 0.70, 0.96, 0}, 
					{0, 0, 1, 0.68, 0.80, 0}, {0, 0, 1, 0.65, 0.70, 1}, {0, 1, 0, 0.64, 0.65, 1}, {1, 0, 0, 0.72, 0.95, 0}, 
					{1, 0, 0, 0.69, 0.70, 0}, {0, 0, 1, 0.75, 0.80, 0}, {1, 0, 0, 0.75, 0.70, 1}, {0, 1, 0, 0.72, 0.90, 1},
					{0, 1, 0, 0.81, 0.75, 0}, {0, 0, 1, 0.71, 0.91, 1}
		};

            //a two-dimensional array of 14 samples and 1 output Neuron
            //14 samples with 1 target output
            double[,] outputDataArray = new Double[,] 
		{ 
				{0}, {0}, {1}, {1}, {1}, {0}, {1}, {0}, {1}, {1}, {1}, {1}, {1}, {0} 
		};

            NeuralNetwork net = new NeuralNetwork();

            int recordCount = inputDataArray.GetUpperBound(0) + 1;


            if (recordCount != (outputDataArray.GetUpperBound(0) + 1))
            {
                throw new System.ArgumentOutOfRangeException("number of samples in input data is not equal to number of samples in output data");
            }


            net.Initialize(inputDataArray, outputDataArray, 4);


            for (int count = 0; count < iterations; count++)
            {
                for (int sample = 0; sample < recordCount; sample++)
                {

                    net.FeedForward(sample);

                    net.BackPropagate();

                    System.Diagnostics.Debug.WriteLine("Count: : " + count + " Output : " + net.output[0].Output + " OutputTraining : " + net.output[0].OutputTraining + " Learning Rate : " + net.learning_rate);
                }

                //adjust the learning rate after every training sample iteration
                //net.learning_rate = (double) (1 / ((double)count + 1));    

                //System.Diagnostics.Debug.WriteLine("Count: : " + count + " Output : " + net.output[0].Output + " OutputTraining : " + net.output[0].OutputTraining + " Learning Rate : " + net.learning_rate);	
            }

        }


        /// <summary>
        /// A Neuron is the basic building block of a Neural Network
        /// </summary>
        public class Neuron
        {

            /// <summary>
            /// Public constructor for initializing a neuron  
            /// </summary>
            /// <param name="layer">Input Layer = 0, Hidden Layer = 1 and Output Layer = 2</param>
            /// <param name="index">A number assigned to a cell for ordering the cell or identifying it</param>
            public Neuron(int layer, int index)
            {

                this.player = layer;

                this.pindex = index;

                //player = 0 is the input layer, however, only hidden and output
                //layers initialize weights and bias to random values
                if (this.player > 0)
                {
                    pbias = NeuralNetwork.Random;

                    if (this.player == 2)
                    {
                        this.pweight = new double[NeuralNetwork.hidden_count];
                    }
                    else
                    {
                        this.pweight = new double[NeuralNetwork.input_count];
                    }


                    for (int i = 0; i < this.Weight.Length; i++)
                    {
                        pweight[i] = NeuralNetwork.Random;

                        System.Diagnostics.Debug.WriteLine("Layer : " + this.player + " Weight " + pweight[i]);
                    }

                }
            }



            /// <summary>
            /// Internal storage for Neuron.Layer public property
            /// </summary>
            protected int player;
            /// <summary>
            /// INPUT LAYER = 0, HIDDEN LAYER = 1, OUTPUT LAYER = 2
            /// </summary>
            public int Layer
            {
                get
                {
                    return this.player;
                }
                set
                {
                    this.player = value;
                }
            }

            /// <summary>
            /// Internal storage for Neuron.Index public property
            /// </summary>
            protected int pindex;
            /// <summary>
            /// Identifies a Neuron or the position of a Neuron in a LAYER
            /// </summary>
            public int Index
            {
                get
                {
                    return this.pindex;
                }
                set
                {
                    this.pindex = value;
                }
            }

            /// <summary>
            /// Internal storage for Neuron.Input public property
            /// </summary>
            protected double pinput;
            /// <summary>
            /// Input data fed to the Neural Network
            /// </summary>
            public double Input
            {
                get
                {
                    return this.pinput;
                }
                set
                {
                    this.pinput = value;

                    //for input layers, neuron input = neuron output while 
                    //an activation function is applied to get an output neuron
                    //in hidden and output layers  
                    if (this.player == 0)
                    {
                        this.poutput = this.pinput;
                    }
                    else
                    {
                        this.poutput = this.LogisticFunction(this.pinput);

                        //System.Diagnostics.Debug.WriteLine("Layer : " + this.player + " Input " + this.pinput + " Output " + this.poutput);				
                    }
                }
            }

            /// <summary>
            /// Internal storage for Neuron.Output public property
            /// </summary>
            protected double poutput;
            /// <summary>
            /// Calculated Ouput from the INPUT, HIDDEN or OUTPUT LAYER
            /// </summary>
            public double Output
            {
                get
                {
                    return this.poutput;
                }
                set
                {
                    this.poutput = value;
                }
            }

            /// <summary>
            /// Internal storage for Neutron.OutputTraining public property
            /// </summary>
            protected double poutputTraining;
            /// <summary>
            /// Expected or Target or Learning output for a neutron
            /// in the OUPUT LAYER
            /// </summary>
            public double OutputTraining
            {
                get
                {
                    return this.poutputTraining;
                }
                set
                {
                    this.poutputTraining = value;
                }
            }

            /// <summary>
            /// Internal storage for Network.Weight public property  
            /// </summary>
            protected double[] pweight;
            /// <summary>
            /// Storage for array of weights from OUTPUT to 
            /// HIDDEN LAYER and from HIDDENLAYER TO INPUT 
            /// LAYER. Each Neuron in the OUTPUT and HIDDEN 
            /// LAYER is connected to an array of Neurons
            /// </summary>
            public double[] Weight
            {
                get
                {
                    return this.pweight;
                }
            }

            /// <summary>
            /// Internal storage for Network.Bias public property
            /// </summary>        
            protected double pbias;
            /// <summary> 
            /// Varies the OUTPUT of a Neuronin a HIDDEN or OUTPUT LAYER 
            /// </summary> 
            public double Bias
            {
                get
                {
                    return this.pbias;
                }
                set
                {
                    this.pbias = value;
                }
            }

            /// <summary>
            /// Internal storage for Network.Error public property
            /// </summary>
            protected double perror;
            /// <summary>
            /// Error = (ACTUALOUTPUT * (1 - ACTUALOUTPUT) * (EXPECTEDOUTPUT - ACTUALOUTPUT)) 
            /// </summary> 
            public double Error
            {
                get
                {
                    return this.perror;
                }
                set
                {
                    this.perror = value;
                }
            }

            /// <summary> 
            /// Sigmoid Function or Logistic Function or Activation Function
            /// is applied to the INPUT to a NETWORK LAYER to get an OUTPUT
            /// </summary> 
            /// <param name="val">
            /// The value to calculate a Sigmoid or Logistic Function for
            /// </param> 
            /// <returns>
            /// System.Double datatype of the Logistic or Sigmoid Function result
            /// </returns> 
            public virtual double LogisticFunction(double val)
            {
                return (1.0 / (1.0 + System.Math.Exp(-val)));
            }


            /// <summary>
            /// Derivative of the Sigmoid Function or Logistic Function or Activation Function
            /// The derivative of the Logistic Activation Function is represented with 
            /// F(x) = F(x)*(1- F(x)) where F(x) is represented by 1/( 1 - e-x ). 
            /// </summary>
            /// <param name="val">
            /// The value to calculate the derivative of the Sigmoid Function for
            /// </param>
            /// <returns>
            /// System.Double datatype of the numeric result
            /// </returns>
            public virtual double LogisticFunctionDerivative(double val)
            {
                double sigmoidValue = 0.0;

                sigmoidValue = this.LogisticFunction(val);

                return (sigmoidValue * (1 - sigmoidValue));
            }
        }


        /// <summary>
        /// A Neural Network Layer or collection of cells or neurons
        /// </summary>
        public class Neurons : System.Collections.CollectionBase
        {

            /// <summary>
            /// Adds a neuron to a Neural Network Layer or collection of cells
            /// </summary>
            /// <param name="newNeuron">
            /// The neuron to add to a Neural Network Layer
            /// </param>
            public virtual void Add(Neuron newNeuron)
            {
                //forward our Add method on to 
                //CollectionBase.IList.Add   
                this.List.Add(newNeuron);
            }

            /// <summary>
            /// Adds a neuron to a Neural Network Layer at a specific position
            /// </summary>
            /// <param name="index">
            /// The position where a neuron will be inserted
            /// </param>
            /// <param name="newNeuron">
            /// The neuron to add to a Neural Network Layer
            /// </param>
            public virtual void Insert(int index, Neuron newNeuron)
            {
                this.List.Insert(index, newNeuron);
            }

            /// <summary>
            /// ReadOnly indexer - retrieves the neuron at a 
            /// specific position orlocation in the Neural 
            /// Network Layer or Neural Network Collection
            /// </summary> 
            public virtual Neuron this[int Index]
            {
                get
                {
                    //return the Neuron at IList[Index] 
                    return (Neuron)this.List[Index];
                }
            }
        }

    }

    /*
     GNU GENERAL PUBLIC LICENSE
    Version 2, June 1991 

    Copyright (C) 1989, 1991 Free Software Foundation, Inc.
    59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
    Everyone is permitted to copy and distribute verbatim copies
    of this license document, but changing it is not allowed.

    Preamble

    The licenses for most software are designed to take away your
    freedom to share and change it. By contrast, the GNU General Public
    License is intended to guarantee your freedom to share and change free
    software--to make sure the software is free for all its users. This
    General Public License applies to most of the Free Software
    Foundation's software and to any other program whose authors commit to
    using it. (Some other Free Software Foundation software is covered by
    the GNU Library General Public License instead.) You can apply it to
    your programs, too.

    When we speak of free software, we are referring to freedom, not
    price. Our General Public Licenses are designed to make sure that you
    have the freedom to distribute copies of free software (and charge for
    this service if you wish), that you receive source code or can get it
    if you want it, that you can change the software or use pieces of it
    in new free programs; and that you know you can do these things.

    To protect your rights, we need to make restrictions that forbid
    anyone to deny you these rights or to ask you to surrender the rights.
    These restrictions translate to certain responsibilities for you if you
    distribute copies of the software, or if you modify it.

    For example, if you distribute copies of such a program, whether
    gratis or for a fee, you must give the recipients all the rights that
    you have. You must make sure that they, too, receive or can get the
    source code. And you must show them these terms so they know their
    rights.

    We protect your rights with two steps: (1) copyright the software, and
    (2) offer you this license which gives you legal permission to copy,
    distribute and/or modify the software.

    Also, for each author's protection and ours, we want to make certain
    that everyone understands that there is no warranty for this free
    software. If the software is modified by someone else and passed on, we
    want its recipients to know that what they have is not the original, so
    that any problems introduced by others will not reflect on the original
    authors' reputations.

    Finally, any free program is threatened constantly by software
    patents. We wish to avoid the danger that redistributors of a free
    program will individually obtain patent licenses, in effect making the
    program proprietary. To prevent this, we have made it clear that any
    patent must be licensed for everyone's free use or not licensed at all.

    The precise terms and conditions for copying, distribution and
    modification follow.

    GNU GENERAL PUBLIC LICENSE
    TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION

    0. This License applies to any program or other work which contains
    a notice placed by the copyright holder saying it may be distributed
    under the terms of this General Public License. The "Program", below,
    refers to any such program or work, and a "work based on the Program"
    means either the Program or any derivative work under copyright law:
    that is to say, a work containing the Program or a portion of it,
    either verbatim or with modifications and/or translated into another
    language. (Hereinafter, translation is included without limitation in
    the term "modification".) Each licensee is addressed as "you".

    Activities other than copying, distribution and modification are not
    covered by this License; they are outside its scope. The act of
    running the Program is not restricted, and the output from the Program
    is covered only if its contents constitute a work based on the
    Program (independent of having been made by running the Program).
    Whether that is true depends on what the Program does.

    1. You may copy and distribute verbatim copies of the Program's
    source code as you receive it, in any medium, provided that you
    conspicuously and appropriately publish on each copy an appropriate
    copyright notice and disclaimer of warranty; keep intact all the
    notices that refer to this License and to the absence of any warranty;
    and give any other recipients of the Program a copy of this License
    along with the Program.

    You may charge a fee for the physical act of transferring a copy, and
    you may at your option offer warranty protection in exchange for a fee.

    2. You may modify your copy or copies of the Program or any portion
    of it, thus forming a work based on the Program, and copy and
    distribute such modifications or work under the terms of Section 1
    above, provided that you also meet all of these conditions:

    a) You must cause the modified files to carry prominent notices
    stating that you changed the files and the date of any change.

    b) You must cause any work that you distribute or publish, that in
    whole or in part contains or is derived from the Program or any
    part thereof, to be licensed as a whole at no charge to all third
    parties under the terms of this License.

    c) If the modified program normally reads commands interactively
    when run, you must cause it, when started running for such
    interactive use in the most ordinary way, to print or display an
    announcement including an appropriate copyright notice and a
    notice that there is no warranty (or else, saying that you provide
    a warranty) and that users may redistribute the program under
    these conditions, and telling the user how to view a copy of this
    License. (Exception: if the Program itself is interactive but
    does not normally print such an announcement, your work based on
    the Program is not required to print an announcement.)

    These requirements apply to the modified work as a whole. If
    identifiable sections of that work are not derived from the Program,
    and can be reasonably considered independent and separate works in
    themselves, then this License, and its terms, do not apply to those
    sections when you distribute them as separate works. But when you
    distribute the same sections as part of a whole which is a work based
    on the Program, the distribution of the whole must be on the terms of
    this License, whose permissions for other licensees extend to the
    entire whole, and thus to each and every part regardless of who wrote it.

    Thus, it is not the intent of this section to claim rights or contest
    your rights to work written entirely by you; rather, the intent is to
    exercise the right to control the distribution of derivative or
    collective works based on the Program.

    In addition, mere aggregation of another work not based on the Program
    with the Program (or with a work based on the Program) on a volume of
    a storage or distribution medium does not bring the other work under
    the scope of this License.

    3. You may copy and distribute the Program (or a work based on it,
    under Section 2) in object code or executable form under the terms of
    Sections 1 and 2 above provided that you also do one of the following:

    a) Accompany it with the complete corresponding machine-readable
    source code, which must be distributed under the terms of Sections
    1 and 2 above on a medium customarily used for software interchange; or,

    b) Accompany it with a written offer, valid for at least three
    years, to give any third party, for a charge no more than your
    cost of physically performing source distribution, a complete
    machine-readable copy of the corresponding source code, to be
    distributed under the terms of Sections 1 and 2 above on a medium
    customarily used for software interchange; or,

    c) Accompany it with the information you received as to the offer
    to distribute corresponding source code. (This alternative is
    allowed only for noncommercial distribution and only if you
    received the program in object code or executable form with such
    an offer, in accord with Subsection b above.)

    The source code for a work means the preferred form of the work for
    making modifications to it. For an executable work, complete source
    code means all the source code for all modules it contains, plus any
    associated interface definition files, plus the scripts used to
    control compilation and installation of the executable. However, as a
    special exception, the source code distributed need not include
    anything that is normally distributed (in either source or binary
    form) with the major components (compiler, kernel, and so on) of the
    operating system on which the executable runs, unless that component
    itself accompanies the executable.

    If distribution of executable or object code is made by offering
    access to copy from a designated place, then offering equivalent
    access to copy the source code from the same place counts as
    distribution of the source code, even though third parties are not
    compelled to copy the source along with the object code.

    4. You may not copy, modify, sublicense, or distribute the Program
    except as expressly provided under this License. Any attempt
    otherwise to copy, modify, sublicense or distribute the Program is
    void, and will automatically terminate your rights under this License.
    However, parties who have received copies, or rights, from you under
    this License will not have their licenses terminated so long as such
    parties remain in full compliance.

    5. You are not required to accept this License, since you have not
    signed it. However, nothing else grants you permission to modify or
    distribute the Program or its derivative works. These actions are
    prohibited by law if you do not accept this License. Therefore, by
    modifying or distributing the Program (or any work based on the
    Program), you indicate your acceptance of this License to do so, and
    all its terms and conditions for copying, distributing or modifying
    the Program or works based on it.

    6. Each time you redistribute the Program (or any work based on the
    Program), the recipient automatically receives a license from the
    original licensor to copy, distribute or modify the Program subject to
    these terms and conditions. You may not impose any further
    restrictions on the recipients' exercise of the rights granted herein.
    You are not responsible for enforcing compliance by third parties to
    this License.

    7. If, as a consequence of a court judgment or allegation of patent
    infringement or for any other reason (not limited to patent issues),
    conditions are imposed on you (whether by court order, agreement or
    otherwise) that contradict the conditions of this License, they do not
    excuse you from the conditions of this License. If you cannot
    distribute so as to satisfy simultaneously your obligations under this
    License and any other pertinent obligations, then as a consequence you
    may not distribute the Program at all. For example, if a patent
    license would not permit royalty-free redistribution of the Program by
    all those who receive copies directly or indirectly through you, then
    the only way you could satisfy both it and this License would be to
    refrain entirely from distribution of the Program.

    If any portion of this section is held invalid or unenforceable under
    any particular circumstance, the balance of the section is intended to
    apply and the section as a whole is intended to apply in other
    circumstances.

    It is not the purpose of this section to induce you to infringe any
    patents or other property right claims or to contest validity of any
    such claims; this section has the sole purpose of protecting the
    integrity of the free software distribution system, which is
    implemented by public license practices. Many people have made
    generous contributions to the wide range of software distributed
    through that system in reliance on consistent application of that
    system; it is up to the author/donor to decide if he or she is willing
    to distribute software through any other system and a licensee cannot
    impose that choice.

    This section is intended to make thoroughly clear what is believed to
    be a consequence of the rest of this License.

    8. If the distribution and/or use of the Program is restricted in
    certain countries either by patents or by copyrighted interfaces, the
    original copyright holder who places the Program under this License
    may add an explicit geographical distribution limitation excluding
    those countries, so that distribution is permitted only in or among
    countries not thus excluded. In such case, this License incorporates
    the limitation as if written in the body of this License.

    9. The Free Software Foundation may publish revised and/or new versions
    of the General Public License from time to time. Such new versions will
    be similar in spirit to the present version, but may differ in detail to
    address new problems or concerns.

    Each version is given a distinguishing version number. If the Program
    specifies a version number of this License which applies to it and "any
    later version", you have the option of following the terms and conditions
    either of that version or of any later version published by the Free
    Software Foundation. If the Program does not specify a version number of
    this License, you may choose any version ever published by the Free Software
    Foundation.

    10. If you wish to incorporate parts of the Program into other free
    programs whose distribution conditions are different, write to the author
    to ask for permission. For software which is copyrighted by the Free
    Software Foundation, write to the Free Software Foundation; we sometimes
    make exceptions for this. Our decision will be guided by the two goals
    of preserving the free status of all derivatives of our free software and
    of promoting the sharing and reuse of software generally.

    NO WARRANTY

    11. BECAUSE THE PROGRAM IS LICENSED FREE OF CHARGE, THERE IS NO WARRANTY
    FOR THE PROGRAM, TO THE EXTENT PERMITTED BY APPLICABLE LAW. EXCEPT WHEN
    OTHERWISE STATED IN WRITING THE COPYRIGHT HOLDERS AND/OR OTHER PARTIES
    PROVIDE THE PROGRAM "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED
    OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE ENTIRE RISK AS
    TO THE QUALITY AND PERFORMANCE OF THE PROGRAM IS WITH YOU. SHOULD THE
    PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF ALL NECESSARY SERVICING,
    REPAIR OR CORRECTION.

    12. IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING
    WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MAY MODIFY AND/OR
    REDISTRIBUTE THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES,
    INCLUDING ANY GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING
    OUT OF THE USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED
    TO LOSS OF DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY
    YOU OR THIRD PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER
    PROGRAMS), EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE
    POSSIBILITY OF SUCH DAMAGES.

    END OF TERMS AND CONDITIONS

    How to Apply These Terms to Your New Programs

    If you develop a new program, and you want it to be of the greatest
    possible use to the public, the best way to achieve this is to make it
    free software which everyone can redistribute and change under these terms.

    To do so, attach the following notices to the program. It is safest
    to attach them to the start of each source file to most effectively
    convey the exclusion of warranty; and each file should have at least
    the "copyright" line and a pointer to where the full notice is found.

    <one line to give the program's name and a brief idea of what it does.>
    Copyright (C) <year> <name of author>

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA


    Also add information on how to contact you by electronic and paper mail.

    If the program is interactive, make it output a short notice like this
    when it starts in an interactive mode:

    Gnomovision version 69, Copyright (C) year name of author
    Gnomovision comes with ABSOLUTELY NO WARRANTY; for details type `show w'.
    This is free software, and you are welcome to redistribute it
    under certain conditions; type `show c' for details.

    The hypothetical commands `show w' and `show c' should show the appropriate
    parts of the General Public License. Of course, the commands you use may
    be called something other than `show w' and `show c'; they could even be
    mouse-clicks or menu items--whatever suits your program.

    You should also get your employer (if you work as a programmer) or your
    school, if any, to sign a "copyright disclaimer" for the program, if
    necessary. Here is a sample; alter the names:

    Yoyodyne, Inc., hereby disclaims all copyright interest in the program
    `Gnomovision' (which makes passes at compilers) written by James Hacker.

    <signature of Ty Coon>, 1 April 1989
    Ty Coon, President of Vice

    This General Public License does not permit incorporating your program into
    proprietary programs. If your program is a subroutine library, you may
    consider it more useful to permit linking proprietary applications with the
    library. If this is what you want to do, use the GNU Library General
    Public License instead of this License.

     */
}
