using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIPathValidator.UIPath;
using UIPathValidator.Validation;
using UIPathValidator.Validation.Result;

namespace TestYourUiPathSolution
{
    class ValidateVerb
    {
        
        public static string Project { get; set; }

        static public int Execute(string loadProject)
        {
            Project project = new Project(loadProject);
            ProjectValidator validator = new ProjectValidator(project);
            project.Load();
            validator.Validate();
            return 0;
        }
    }
}
