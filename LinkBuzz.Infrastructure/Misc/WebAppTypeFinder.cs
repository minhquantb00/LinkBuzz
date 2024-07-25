using LinkBuzz.Domain.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Infrastructure.Misc
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Fields

        private bool _binFolderAssembliesLoaded;

        #endregion

        #region Ctor

        public WebAppTypeFinder(IAppFileProvider fileProvider = null) : base(fileProvider)
        {
        }

        #endregion

        #region Properties
        public bool EnsureBinFolderAssembliesLoaded { get; set; } = true;

        #endregion

        #region Methods

        public virtual string GetBinDirectory()
        {
            return AppContext.BaseDirectory;
        }
        public override IList<Assembly> GetAssemblies()
        {
            if (!EnsureBinFolderAssembliesLoaded || _binFolderAssembliesLoaded)
                return base.GetAssemblies();

            _binFolderAssembliesLoaded = true;
            var binPath = GetBinDirectory();
            LoadMatchingAssemblies(binPath);

            return base.GetAssemblies();
        }

        #endregion
    }
}
