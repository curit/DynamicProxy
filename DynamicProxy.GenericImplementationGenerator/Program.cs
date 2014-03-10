using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy.GenericImplementationGenerator
{
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.IO;
    using Microsoft.CSharp;

    class Program
    {
        static void Main(string[] args)
        {
            var ccu = new CodeCompileUnit();
            var ns = new CodeNamespace("DynamicProxy");
            ccu.Namespaces.Add(ns);
            
            var partialIProxyInterface = new CodeTypeDeclaration("IProxy") {IsPartial = true, IsInterface = true};

            for (int i = 1; i <= 15; i++)
            {
                var funcMeth = new CodeMemberMethod {Name = "AddInterceptor", ReturnType = new CodeTypeReference("IProxy")};
                var funcAction = new CodeMemberMethod { Name = "AddInterceptor", ReturnType = new CodeTypeReference("IProxy") };
                var func = new CodeTypeReference(typeof (Func<>));
                var innerFunc = new CodeTypeReference(typeof(Func<>));
                var action = new CodeTypeReference(typeof(Action<>));
                var innerAction = new CodeTypeReference(typeof(Action<>));
                func.TypeArguments.Add(innerFunc);
                action.TypeArguments.Add(innerAction);

                AddTypeArgs(func.TypeArguments, i);
                AddTypeArgs(action.TypeArguments, i);

                for (int j = 1; j <= i; j++)
                {
                    funcAction.TypeParameters.Add("T" + j);
                    funcMeth.TypeParameters.Add("T" + j);
                    action.TypeArguments.Add("T" + j);
                    innerAction.TypeArguments.Add("T" + j);
                    func.TypeArguments.Add("T" + j);
                    innerFunc.TypeArguments.Add("T" + j);
                }
                
                funcAction.Parameters.Add(new CodeParameterDeclarationExpression(action, "func"));
                funcMeth.Parameters.Add(new CodeParameterDeclarationExpression(func, "func"));
                partialIProxyInterface.Members.Add(funcMeth);
                partialIProxyInterface.Members.Add(funcAction);
            }
            ns.Types.Add(partialIProxyInterface);

            var provider = new CSharpCodeProvider();
            using (var sw = new StreamWriter("IProxy.Generated.cs", false))
            using (var tw = new IndentedTextWriter(sw, "    "))
            {
                provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
            }
        }

        static void AddTypeArgs(CodeTypeReferenceCollection c, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                c.Add(new CodeTypeReference("T" + i));
            }
        }
    }
}
