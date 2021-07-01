using System.Text;

namespace CodeGenerator.Helpers
{
    public class CodeBuilder
    {
        public string _solutionName { get; set; }
        public string _className { get; set; }
        public CodeBuilder(string solutionName, string className)
        {
            _solutionName = solutionName;
            _className = className;
            CreateClass();
        }

        public void CreateClass()
        {
            //Root of classes to be created
            var root = $"{_solutionName}\\MyProject\\MyModels\\MyEntity";
            var sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("");
            sb.AppendLine("namespace MyProject.Models");
            sb.AppendLine("{");
            sb.AppendFormat("    public class {0}\r\n", _className);
            sb.AppendLine("    {");
            sb.AppendLine("        public Guid Id { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public string Name { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public Guid? ModifiedBy { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public DateTime? CreatedOn { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public DateTime? ModifiedOn { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public SystemUser CreatedBy { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            Methods.CreateFile(sb.ToString(), root, $"{_className}Request.cs");
        }
    }
}
