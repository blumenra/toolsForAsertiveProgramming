using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    [TestFixture]
    class AssertionToolTests
    {
        [TestCase]
        public void GenerateMethod()
        {
            string indentation = "\t";

            string method = "";
            method += "method MM1(q: seq<int>) returns(i: nat, q0: seq<int>, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += indentation + "ensures i == |q|\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";


            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("q0", "seq<int>"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void GenerateLemma()
        {
            string indentation = "\t";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, i: nat, q0: seq<int>, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "requires i == |q|\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";


            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("q0", "seq<int>"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");

            string name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(lemma, ds.generateStrengthLemma());
        }

        [TestCase]
        public void GenerateBody()
        {
            string body = "";
            body += "var i : nat;\n";
            body += "var q' : seq<int>;\n";
            body += "assert 0 < |q|;\n";
            body += "i, q', min, max := MM1(q);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "assert i == |q|;\n";
            body += "L1(q, i, q', min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("q'", "seq<int>"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
        }

        [TestCase]
        public void AllTogether()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "var q' : seq<int>;\n";
            body += "assert 0 < |q|;\n";
            body += "i, q', min, max := MM1(q);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "assert i == |q|;\n";
            body += "L1(q, i, q', min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, i: nat, q': seq<int>, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "requires i == |q|\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";

            string method = "";
            method += "method MM1(q: seq<int>) returns(i: nat, q': seq<int>, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += indentation + "ensures i == |q|\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";


            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("q'", "seq<int>"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");


            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateStrengthLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void StrengthenPostCondition()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "assert 0 < |q|;\n";
            body += "i, min, max := MM1(q);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "assert i == |q|;\n";
            body += "assert i <= 100;\n";
            body += "L1(q, i, min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, i: nat, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "requires i == |q|\n";
            lemma += indentation + "requires i <= 100\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";

            string method = "";
            method += "method MM1(q: seq<int>) returns(i: nat, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += indentation + "ensures i == |q|\n";
            method += indentation + "ensures i <= 100\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";


            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");

            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("i == |q|");
            ds.strengthenPostCond("i <= 100");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateStrengthLemma());
            //Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void WeakenPreCondition()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "assert 0 < |q|;\n";
            body += "L1(q, i, min, max);\n";

            body += "assert Inv2(q, i, min, max);\n";
            body += "assert Inv3(q, i, min, max);\n";

            body += "i, min, max := MM1(q);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, i: nat, min: int, max: int)\n";
            lemma += indentation + "requires 0 < |q|\n";
            lemma += indentation + "ensures Inv2(q, i, min, max)\n";
            lemma += indentation + "ensures Inv3(q, i, min, max)\n";

            string method = "";
            method += "method MM1(q: seq<int>) returns(i: nat, min: int, max: int)\n";
            method += indentation + "requires Inv2(q, i, min, max)\n";
            method += indentation + "requires Inv3(q, i, min, max)\n";
            method += indentation + "ensures MinElement(min, q)\n";
            method += indentation + "ensures MaxElement(max, q)\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";



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

            //Console.WriteLine("WeakenPreCondition:");
            //Console.WriteLine(body);
            //Console.WriteLine(lemma);
            //Console.WriteLine(method);
            //Console.ReadLine();

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateWeakLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void MultipleLocalVariables()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "var q' : seq<int>;\n";
            body += "var j' : int;\n";
            body += "var k' : nat;\n";
            body += "assert 0 < |q|;\n";
            body += "i, q', j', k', min, max := MM1(q);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "L1(q, i, q', j', k', min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, i: nat, q': seq<int>, j': int, k': nat, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";

            string method = "";
            method += "method MM1(q: seq<int>) returns(i: nat, q': seq<int>, j': int, k': nat, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";

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

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateStrengthLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void MultipleArguments()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "assert 0 < |q|;\n";
            body += "i, min, max := MM1(q, a, b);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "L1(q, a, b, i, min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, a: nat, b: nat, i: nat, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";

            string method = "";
            method += "method MM1(q: seq<int>, a: nat, b: nat) returns(i: nat, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";

            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddArgument(new Variable("a", "nat"));
            ds.AddArgument(new Variable("b", "nat"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateStrengthLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void IdenticalValues()
        {
            string indentation = "\t";

            string body = "";
            body += "var i : nat;\n";
            body += "assert 0 < |q|;\n";
            body += "i, min, max := MM1(q, a, b);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "L1(q, a, b, i, min, max);\n";
            body += "assert MinElement(min, q);\n";
            body += "assert MaxElement(max, q);\n";

            string lemma = "";
            lemma += "lemma L1(q: seq<int>, a: nat, b: nat, i: nat, min: int, max: int)\n";
            lemma += indentation + "requires Inv(q, i, min, max)\n";
            lemma += indentation + "ensures MinElement(min, q)\n";
            lemma += indentation + "ensures MaxElement(max, q)\n";

            string method = "";
            method += "method MM1(q: seq<int>, a: nat, b: nat) returns(i: nat, min: int, max: int)\n";
            method += indentation + "requires 0 < |q|\n";
            method += indentation + "ensures Inv(q, i, min, max)\n";
            method += "{\n";
            method += indentation + "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";

            assertiveToolDS ds = new assertiveToolDS();

            ds.Name = "MinAndMax";
            ds.AddArgument(new Variable("q", "seq<int>"));
            ds.AddArgument(new Variable("a", "nat"));
            ds.AddArgument(new Variable("b", "nat"));
            ds.AddArgument(new Variable("b", "nat"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddLoclVar(new Variable("i", "nat"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("min", "int"));
            ds.AddRetValue(new Variable("max", "int"));
            ds.AddPreCond("0 < |q|");
            ds.AddPreCond("0 < |q|");
            ds.AddPostCond("MinElement(min, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.AddPostCond("MaxElement(max, q)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("Inv(q, i, min, max)");
            ds.strengthenPostCond("Inv(q, i, min, max)");

            string name;

            name = "MM1";
            ds.NewMethod.Name = name;

            name = "L1";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateStrengthLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }

        [TestCase]
        public void args0WithSameInRet()
        {
            string indentation = "\t";

            string body = "";
            body += "i, min, max := i0, min0, max0;\n";
            body += "assert 0 < |q| && min == q[0] && max == q[0] && i == 1;\n";
            body += "L3(q, i, min, max);\n";
            body += "assert Inv(q, i, min, max);\n";
            body += "assert i > min && max < q;\n";
            
            body += "i, min, max := MM3(q, i, min, max);\n";
            body += "assert Inv(q, i, min, max) && i == |q|;\n";

            string lemma = "";
            lemma += "lemma L3(q: seq<int>, i: nat, min: int, max: int)\n";
            lemma += indentation + "requires 0 < |q| && min == q[0] && max == q[0] && i == 1\n";
            lemma += indentation + "ensures Inv(q, i, min, max)\n";
            lemma += indentation + "ensures i > min && max < q\n";
            


            string method = "";
            method += "method MM3(q: seq<int>, i0: nat, min0: int, max0: int) returns(i: nat, min: int, max: int)\n";
            method += indentation + "requires Inv(q, i0, min0, max0)\n"; //@@@
            method += indentation + "requires i0 > min0 && max0 < q\n"; //@@@
            method += indentation + "ensures Inv(q, i, min, max) && i == |q|\n";
            method += "{\n";
            method += indentation + "i, min, max := i0, min0, max0;\n";
            method += "\n";
            method += indentation + "// Implement here...\n";
            method += "}\n";


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
            ds.weakenPreCond("i > min && max < q");
            


            string name;

            name = "MM3";
            ds.NewMethod.Name = name;

            name = "L3";
            ds.WeakLemma.Name = name;

            name = "L2";
            ds.StrengthLemma.Name = name;

            Assert.AreEqual(body, ds.generateBody());
            Assert.AreEqual(lemma, ds.generateWeakLemma());
            Assert.AreEqual(method, ds.generateMethod());
        }
    }
}

