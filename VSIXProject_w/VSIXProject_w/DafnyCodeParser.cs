using System;
using System.Collections.Generic;
using Microsoft.Dafny;


namespace VSIXProject_w
{
    class DafnyCodeParser
    {
        
        public Program dafny_program;
        public Microsoft.Dafny.Method currentMethod;

        public DafnyCodeParser()
        {
            dafny_program = null;
            currentMethod = null;
        }

        public Boolean parse_file(string filename, string methodname)
        {
            // init parser arguments
            DafnyFile usedFile = new DafnyFile(filename);
            var files = new List<DafnyFile>();
            files.Add(usedFile);
            ErrorReporter r = new ConsoleErrorReporter();
            Microsoft.Dafny.Program ret;
            DafnyOptions.Install(new DafnyOptions(r));

            // run parser
            string err = Main.ParseCheck(files, filename, r, out ret);
            //if (err != null)
            //{
            //    return false;
            //}

            // program parsed well
            dafny_program = ret;

            // list of all methods
            var decls = ret.Modules();
            List<TopLevelDecl> a = new List<TopLevelDecl>();
            foreach (Microsoft.Dafny.ModuleDefinition dec in decls)
            {
                a.AddRange(dec.TopLevelDecls);
            }

            // look for methodname
            var callables = ModuleDefinition.AllCallables(a);
            foreach (Microsoft.Dafny.ICallable method in callables)
            {
                if (method is Microsoft.Dafny.Method)
                {
                    Microsoft.Dafny.Method m = (Microsoft.Dafny.Method)method;
                    if (m.Name == methodname)
                    {
                        currentMethod = m;
                        return true;
                    }

                }
            }

            return false;
            
        }

        public List<string> get_var_names()
        {
            List<string> ansList = new List<string>();
            foreach (Formal f in currentMethod.Ins)
            {
                ansList.Add(f.DisplayName);
            }
            return ansList;
        }

        public List<string> get_var_types()
        {
            List<string> ansList = new List<string>();
            foreach (Formal f in currentMethod.Ins)
            {
                ansList.Add(f.SyntacticType.ToString());
            }
            return ansList;
        }

        public List<string> get_ret_names()
        {
            List<string> ansList = new List<string>();
            foreach (Formal f in currentMethod.Outs)
            {
                ansList.Add(f.DisplayName);
            }
            return ansList;
        }

        public List<string> get_ret_types()
        {
            List<string> ansList = new List<string>();
            foreach (Formal f in currentMethod.Outs)
            {
                ansList.Add(f.SyntacticType.ToString());
            }
            return ansList;
        }

        public List<string> get_req()
        {
            StatementGenerator helper = new StatementGenerator(null);
            List<string> ansList = new List<string>();
            foreach (MaybeFreeExpression f in currentMethod.Req)
            {
                
                ansList.Add(helper.GenerateString(f.E));
                
            }
            return ansList;
        }

        public List<string> get_ens()
        {
            StatementGenerator helper = new StatementGenerator(null);
            List<string> ansList = new List<string>();
            foreach (MaybeFreeExpression f in currentMethod.Ens)
            {
                ansList.Add(helper.GenerateString(f.E));
            }
            return ansList;
        }

    }
}
