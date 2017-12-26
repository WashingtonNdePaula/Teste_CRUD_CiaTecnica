using System;
using System.Reflection;

namespace Teste_CRUD_CiaTecnica.Presentation.WebApi.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}