﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Create multisig address
    /// </summary>
    class CreateMultisigAddressMethodClass : AbstractMethodClass // commands.py signature createmultisig(self, num, pubkeys):
    {
        public override string method => "createmultisig";
        public string num;
        public string pubkeys;
        public CreateMultisigAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("num", num);
            options.Add("pubkeys", pubkeys);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
