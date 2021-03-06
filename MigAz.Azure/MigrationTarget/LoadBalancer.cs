﻿using MigAz.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigAz.Azure.MigrationTarget
{
    public class LoadBalancer : IMigrationTarget
    {
        private String _SourceName = String.Empty;
        private string _TargetName = String.Empty;
        private ILoadBalancer _source;
        private List<FrontEndIpConfiguration> _FrontEndIpConfiguration = new List<FrontEndIpConfiguration>();
        private List<BackEndAddressPool> _BackEndAddressPools = new List<BackEndAddressPool>();
        private List<LoadBalancingRule> _LoadBalancingRules = new List<LoadBalancingRule>();
        private List<InboundNatRule> _InboundNatRules = new List<InboundNatRule>();
        private List<Probe> _Probes = new List<Probe>();

        public LoadBalancer(Arm.LoadBalancer sourceLoadBalancer)
        {
            this.Source = sourceLoadBalancer;
            this.Name = sourceLoadBalancer.Name;

        }

        public LoadBalancer()
        {
        }

        public ILoadBalancer Source
        {
            get { return _source; }
            set
            {
                _source = value;
            }
        }

        public String SourceName
        {
            get
            {
                if (this.Source == null)
                    return _SourceName;
                else
                    return this.Source.Name;
            }
            set
            {
                _SourceName = value;
            }
        }

        public List<BackEndAddressPool> BackEndAddressPools
        {
            get { return _BackEndAddressPools; }
            set { _BackEndAddressPools = value; }
        }
        public List<FrontEndIpConfiguration> FrontEndIpConfigurations
        {
            get { return _FrontEndIpConfiguration; }
            set { _FrontEndIpConfiguration = value; }
        }

        public List<InboundNatRule> InboundNatRules
        {
            get { return _InboundNatRules; }
        }

        public List<Probe> Probes
        {
            get { return _Probes; }
        }

        public List<LoadBalancingRule> LoadBalancingRules
        {
            get { return _LoadBalancingRules; }
        }

        public String StaticVirtualNetworkIPAddress
        {
            get;set;
        }

        public string Name
        {
            get { return _TargetName; }
            set { _TargetName = value.Trim().Replace(" ", String.Empty); }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
