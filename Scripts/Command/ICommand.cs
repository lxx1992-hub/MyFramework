using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����ӿڣ�ͳһ��������
/// </summary>
namespace MyFramework
{
    public interface ICommand
    {
        void Execute();
        void Execute(Object obj);
    }
}
