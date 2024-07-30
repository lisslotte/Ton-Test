using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonSdk.Connect;
using TonSdk.Core;
using UnityEngine;
using Wallet = TonSdk.Connect.Wallet;

public class Test : MonoBehaviour
{
    public string toAddress;

    public TonConnectHandler handler;


    public async void Send()
    {
        var msg = new Message();
        msg.Address = new Address(toAddress);
        msg.Amount = new Coins(1);
        var req = new SendTransactionRequest(new Message[]{msg});
        Task<SendTransactionResult?> transactionTask = handler.tonConnect.SendTransaction(req);
        SendTransactionResult? result = await transactionTask;
        Debug.Log("TonDebug:tx2: " + result.Value.Boc);
    }
}