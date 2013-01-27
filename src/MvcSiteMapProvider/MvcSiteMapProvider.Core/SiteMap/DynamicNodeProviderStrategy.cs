﻿// -----------------------------------------------------------------------
// <copyright file="DynamicNodeProviderStrategy.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcSiteMapProvider.Core.SiteMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DynamicNodeProviderStrategy
        : IDynamicNodeProviderStrategy
    {
        public DynamicNodeProviderStrategy(IDynamicNodeProvider[] dynamicNodeProviders)
        {
            if (dynamicNodeProviders == null)
                throw new ArgumentNullException("dynamicNodeProviders");

            this.dynamicNodeProviders = dynamicNodeProviders;
        }

        private readonly IDynamicNodeProvider[] dynamicNodeProviders;

        #region IDynamicNodeProviderStrategy Members

        public IDynamicNodeProvider GetProvider(string providerName)
        {
            return dynamicNodeProviders.FirstOrDefault(x => x.AppliesTo(providerName));
        }

        public IEnumerable<DynamicNode> GetDynamicNodeCollection(string providerName)
        {
            var provider = GetProvider(providerName);
            if (provider == null) return new List<DynamicNode>();
            return provider.GetDynamicNodeCollection();
        }


        public CacheDescription GetCacheDescription(string providerName)
        {
            var provider = GetProvider(providerName);
            if (provider == null) return null;
            return provider.GetCacheDescription();
        }

        #endregion
    }
}