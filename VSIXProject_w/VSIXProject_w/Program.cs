using System;
using System.Collections.Generic;

namespace VSIXProject_w
{
    public class AssertiveTool
    {
        static int Main(string[] args)
        {

            //go(initDs1());
            //go(initDs2());
            //go(initDs3());
            //go(initDs4());
            go(initDs5());




            Console.WriteLine("\nExiting..");
            Console.ReadLine();
            return 0;
        }

        public static void go(assertiveToolDS ds)
        {
            //Console.WriteLine(ds.generatePMethod());
            //Console.WriteLine("");

            Console.WriteLine(ds.generateBody());

            Console.WriteLine(ds.generateMethod());
            Console.WriteLine("");
            Console.WriteLine(ds.generateWeakLemma());
            Console.WriteLine("");
            Console.WriteLine(ds.generateStrengthLemma());
        }

        public static assertiveToolDS initDs1()
        {
            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax'";

            ds.AddArgument(new Variable("q", "seq<int>"));
            //ds.AddArgument(new Variable("j0", "nat"));
            //ds.AddArgument(new Variable("min", "int"));
            //ds.AddArgument(new Variable("max", "int"));
            //ds.AddArgument(new Variable("a", "nat"));
            //ds.AddArgument(new Variable("b", "int"));

            ds.AddLoclVar(new Variable("i", "nat"));
            //ds.AddLoclVar(new Variable("q0", "seq<int>"));
            //ds.AddLoclVar(new Variable("j0", "int"));
            //ds.AddLoclVar(new Variable("k0", "nat"));

            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));

            ds.AddPreCond("0 < |q|");
            //ds.AddPreCond("|q| < 100");

            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            //ds.AddPostCond("q != null");

            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");

            //ds.weakenPreCond("|q| < 0");


            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.WeakLemma.Name = name;

            name = "L2";
            ds.StrengthLemma.Name = name;

            return ds;
        }

        public static assertiveToolDS initDs2()
        {
            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MM2'";

            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddArgument(new Variable("i0", "nat"));
            ds.AddArgument(new Variable("min0", "int"));
            ds.AddArgument(new Variable("max0", "int"));
            //ds.AddArgument(new Variable("a", "nat"));
            //ds.AddArgument(new Variable("b", "int"));

            //ds.AddLoclVar(new Variable("k", "nat"));
            //ds.AddLoclVar(new Variable("min", "int"));
            //ds.AddLoclVar(new Variable("max", "int"));
            //ds.AddLoclVar(new Variable("q0", "seq<int>"));
            //ds.AddLoclVar(new Variable("j0", "int"));
            //ds.AddLoclVar(new Variable("k0", "nat"));

            ds.AddRetValue(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));

            ds.AddPreCond("0 < |q| && min0 == q[0] && max0 == q[0] && i0 == 1");
            //ds.AddPreCond("|q| < 100");

            ds.AddPostCond("Inv(q, i, min, max) && i == |q|");
            //ds.AddPostCond("q != null");

            //ds.strengthenPostCond("Inv(q, i, min, max)");
            //ds.strengthenPostCond("i == |q|");

            ds.weakenPreCond("Inv(q, i, min, max)");


            string name;

            name = "MM3";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.WeakLemma.Name = name;

            name = "L2";
            ds.StrengthLemma.Name = name;

            return ds;
        }

        public static assertiveToolDS initDs3()
        {
            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.weakenPreCond("Inv2(q, i, min, max)");
            ds.weakenPreCond("Inv3(q, i, min, max)");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.WeakLemma.Name = name;

            return ds;
        }

        public static assertiveToolDS initDs4()
        {
            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("q'", "seq<int>"));
            ds.AddLoclVar(new Variable("j'", "int"));
            ds.AddLoclVar(new Variable("k'", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("Inv(q, i, min, max)");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            
            return ds;
        }

        public static assertiveToolDS initDs5()
        {
            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MM2'";

            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddArgument(new Variable("i0", "nat"));
            ds.AddArgument(new Variable("min0", "int"));
            ds.AddArgument(new Variable("max0", "int"));
            ds.AddRetValue(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q| && min0 == q[0] && max0 == q[0] && i0 == 1");
            ds.AddPostCond("Inv(q, i, min, max) && i == |q|");
            ds.weakenPreCond("Inv(q, i, min, max)");


            string name;

            name = "MM3";
            ds.NewMethod.Name = name;

            name = "L3";
            ds.WeakLemma.Name = name;

            name = "L2";
            ds.StrengthLemma.Name = name;

                        
            return ds;
        }
}
}
