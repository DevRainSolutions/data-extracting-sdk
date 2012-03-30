namespace DevRain.Data.Mining
{

    //http://www.codeproject.com/KB/recipes/AprioriAlgorithm.aspx

    // http://sourceforge.net/projects/aprioricsharp/
    //http://aprioricsharp.sourceforge.net/
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.IO;
    /*
        static void Main(string[] args)
        {


            string file = @"c:\test.csv";
            string sup = "2";
            if (args.Length > 0)
            {
                file = args[0];

            }
            if (args.Length == 2)
            {
                sup = args[1];

            }


            double support = double.Parse(sup);

            CSVReader cr = new CSVReader();
            ItemSet data = cr.Read(file);

            Program p = new Program();
            ItemSet a = p.apriori(data, support);
            for (int i = 0; i < a.Count; i++)
            {
                ItemSet cur = (ItemSet)a[i];
                for (int j = 0; j < cur.Count; j++)
                {
                    ItemSet now = (ItemSet)cur[j];
                    foreach (DataItem item in now)
                    {

                        Console.Write("编号" + item.Id + ":" + item.ItemName + "  ");


                    }
                    Console.WriteLine("  支持度:" + now.ICount);
                }

            }
            Console.Read();
        }
     */

    public class Apriori
    {
        private ItemSet FindOneColSet(ItemSet data, double support)
        {
            ItemSet cur = null;
            ItemSet result = new ItemSet();

            ItemSet set = null;
            ItemSet newset = null;
            DataItem cd = null;
            DataItem td = null;
            bool flag = true;

            for (int i = 0; i < data.Count; i++)
            {
                cur = (ItemSet)data[i];
                for (int j = 0; j < cur.Count; j++)
                {
                    cd = (DataItem)cur[j];

                    for (int n = 0; n < result.Count; n++)
                    {
                        set = (ItemSet)result[n];
                        td = (DataItem)set[0];
                        if (cd.Id == td.Id)
                        {
                            set.ICount++;
                            flag = false;
                            break;

                        }
                        flag = true;
                    }
                    if (flag)
                    {
                        newset = new ItemSet();
                        newset.Add(cd);
                        result.Add(newset);
                        newset.ICount = 1;


                    }



                }



            }
            ItemSet finalResult = new ItemSet();
            for (int i = 0; i < result.Count; i++)
            {
                ItemSet con = (ItemSet)result[i];
                if (con.ICount >= support)
                {

                    finalResult.Add(con);
                }


            }
            //finalResult.Sort();
            return finalResult;


        }


        private ItemSet apriori(ItemSet data, double support)
        {

            ItemSet result = new ItemSet();
            ItemSet li = new ItemSet();
            ItemSet conList = new ItemSet();
            ItemSet subConList = new ItemSet();
            ItemSet subDataList = new ItemSet();
            int k = 2;
            li.Add(new ItemSet());
            li.Add(this.FindOneColSet(data, support));

            while (((ItemSet)li[k - 1]).Count != 0)
            {

                conList = AprioriGenerate((ItemSet)li[k - 1], k - 1, support);
                for (int i = 0; i < data.Count; i++)
                {
                    subDataList = SubSet((ItemSet)data[i], k);
                    for (int j = 0; j < subDataList.Count; j++)
                    {
                        for (int n = 0; n < conList.Count; n++)
                        {
                            ((ItemSet)subDataList[j]).Sort();
                            ((ItemSet)conList[n]).Sort();
                            if (((ItemSet)subDataList[j]).Equals(conList[n]))
                            {
                                ((ItemSet)conList[n]).ICount++;

                            }
                        }

                    }

                }

                li.Add(new ItemSet());
                for (int i = 0; i < conList.Count; i++)
                {
                    ItemSet con = (ItemSet)conList[i];
                    if (con.ICount >= support)
                    {

                        ((ItemSet)li[k]).Add(con);
                    }


                }

                k++;
            }
            for (int i = 0; i < li.Count; i++)
            {

                result.Add(li[i]);



            }
            return result;



        }

        private ItemSet AprioriGenerate(ItemSet li, int k, double support)
        {

            ItemSet curList = null;
            ItemSet durList = null;
            ItemSet candi = null;
            ItemSet result = new ItemSet();
            for (int i = 0; i < li.Count; i++)
            {
                for (int j = 0; j < li.Count; j++)
                {
                    bool flag = true;
                    curList = (ItemSet)li[i];
                    durList = (ItemSet)li[j];
                    for (int n = 2; n < k; n++)
                    {

                        if (((DataItem)curList[n - 2]).Id == ((DataItem)durList[n - 2]).Id)
                        {

                            flag = true;

                        }
                        else
                        {
                            break;
                            flag = false;


                        }


                    }

                    if (flag && ((DataItem)curList[k - 1]).Id < ((DataItem)durList[k - 1]).Id)
                    {

                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        candi = new ItemSet();


                        for (int m = 0; m < k; m++)
                        {
                            candi.Add(durList[m]);

                        }
                        candi.Add(curList[k - 1]);





                        if (HasInFrequentSubset(candi, li, k))
                        {
                            candi.Clear();

                        }
                        else
                        {
                            result.Add(candi);
                        }
                    }

                }
            }
            return result;

        }



        private bool HasInFrequentSubset(ItemSet candidate, ItemSet li, int k)
        {
            ItemSet subSet = SubSet(candidate, k);
            ItemSet curList = null;
            ItemSet liCurList = null;

            for (int i = 0; i < subSet.Count; i++)
            {
                curList = (ItemSet)subSet[i];
                for (int j = 0; j < li.Count; j++)
                {

                    liCurList = (ItemSet)li[j];
                    if (liCurList.Equals(curList))
                    {
                        return false;

                    }

                }
            }
            return true; ;
        }
        private ItemSet SubSet(ItemSet set)
        {
            ItemSet subSet = new ItemSet();

            ItemSet itemSet = new ItemSet();
            int num = 1 << set.Count;

            int bit;
            int mask = 0; ;
            for (int i = 0; i < num; i++)
            {
                itemSet = new ItemSet();
                for (int j = 0; j < set.Count; j++)
                {
                    mask = 1 << j;
                    bit = i & mask;
                    if (bit > 0)
                    {

                        itemSet.Add(set[j]);

                    }
                }
                if (itemSet.Count > 0)
                {
                    subSet.Add(itemSet);
                }


            }



            return subSet;
        }



        private ItemSet SubSet(ItemSet set, int t)
        {
            ItemSet subSet = new ItemSet();

            ItemSet itemSet = new ItemSet();
            int num = 1 << set.Count;

            int bit;
            int mask = 0; ;
            for (int i = 0; i < num; i++)
            {
                itemSet = new ItemSet();
                for (int j = 0; j < set.Count; j++)
                {
                    mask = 1 << j;
                    bit = i & mask;
                    if (bit > 0)
                    {

                        itemSet.Add(set[j]);

                    }
                }
                if (itemSet.Count == t)
                {
                    subSet.Add(itemSet);
                }


            }



            return subSet;
        }
    }

    /// <summary>
    /// Summary description for ItemSet
    /// </summary>
    public class ItemSet : ArrayList
    {
        public ItemSet()
        {
            //
            // TODO: Add constructor logic here
            //

        }


        private int icount = 0;

        public int ICount
        {
            get { return icount; }
            set { icount = value; }
        }
        public override object Clone()
        {
            ArrayList al = (ArrayList)base.Clone();
            ItemSet set = new ItemSet();
            for (int i = 0; i < al.Count; i++)
            {

                set.Add(al[i]);
            }


            set.ICount = this.icount;
            return set;
        }
        public override bool Equals(object obj)
        {

            ArrayList al = (ArrayList)obj;

            //al.Sort(StringComparer.CurrentCulture);
            //this.Sort(StringComparer.CurrentCulture);
            if (al.Count != this.Count) return false;
            for (int i = 0; i < al.Count; i++)
            {

                if (!al[i].Equals(this[i]))
                {
                    return false;
                }
            }
            return true;

        }
    }

    public class DataItem : IComparable
    {
        public DataItem()
        {

        }
        public DataItem(int id)
        {
            this.Id = id;

        }
        public DataItem(int id, string itemName)
        {
            this.Id = id;
            this.ItemName = itemName;

        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            DataItem di = (DataItem)obj;
            return di.Id.Equals(this.Id);
        }

        public int CompareTo(object obj)
        {
            DataItem di = (DataItem)obj;
            return this.Id.CompareTo(di.Id);

        }
    }

  
 
    class CSVReader
    {
        public CSVReader() { 
        
        
        }
        public ItemSet Read(string fileName) {

            ItemSet rowSet = new ItemSet();
            ItemSet colSet = null;
            string col="";
            string[] head=null;
            if (File.Exists(fileName))
            {
                // Create a file to write to.

                StreamReader sr = new StreamReader(File.OpenRead(fileName), Encoding.Default, true);
                string row = "";
                int k = 0;
                while(!sr.EndOfStream){
                    k++;
                    row=sr.ReadLine();
                    
                    string[] cols=row.Split(",".ToCharArray());
                    
                    if (k == 1)
                    {
                        head=cols;

                    }
                    else {

                        colSet = new ItemSet();

                        for(int i=1;i<cols.Length+1;i++)
                        {
                            col=cols[i-1];
                            if (col.Equals("1"))
                            {
                                colSet.Add(new DataItem(i,head[i-1]));
                            }


                        }

                        rowSet.Add(colSet);
                    }


                }
              
             
               
                sr.Close();
               


            }
            return rowSet;
        }
    }
    
}
