using System.Collections;
using System.Reflection;
using System.Windows;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Handlers;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Implementation
{
    internal class ViewModelMappingService : IViewModelMappingService
    {
        private readonly IDataTemplateFactory _dataTemplateFactory;
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;
        private readonly IViewViewModelMapFactory _viewViewModelMapFactory;

        public ViewModelMappingService(
            IResourceDictionaryFactory resourceDictionaryFactory,
            IDataTemplateFactory dataTemplateFactory,
            IViewViewModelMapFactory viewViewModelMapFactory)
        {
            _resourceDictionaryFactory = resourceDictionaryFactory;
            _dataTemplateFactory = dataTemplateFactory;
            _viewViewModelMapFactory = viewViewModelMapFactory;
        }

        public void Initialize(Assembly rootAssembly)
        {
            var resourceDictionary = _resourceDictionaryFactory.CreateEmpty();
            var maps = _viewViewModelMapFactory.CreateAllMaps(rootAssembly);

            foreach (var map in maps)
            {
                ApplyDataTemplate(resourceDictionary, map);
            }

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void ApplyDataTemplate(IDictionary resourceDictionary, ViewViewModelMap map)
        {
            var dataTemplate = _dataTemplateFactory.CreateWithMapping(map);
            resourceDictionary.Add(dataTemplate.DataTemplateKey, dataTemplate);
        }
    }
}