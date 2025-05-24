using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    
    // 基类包括三个功能单例成员，显示面板，隐蒎面板
    //单例模式的基类,//私有的静态成员变量（申明）
    private static T instance;
    //公共的静态成员属性或者方法（获取）
    public static T Instance => instance;
    
    void Awake()
    {

        
            //注意配合where T : class约束传入的一定要是一个类
            //在Awake中初始化的原因是
            //我们的面板脚本在场景上肯定只会挂载一次
            //那么我们可以在这个脚本的生命周期函数的Awake中
            //直接记录场景上唯一的这个脚本，这里的静态字段直接指向实例
            instance = this as T;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //为了方便外部访问和子类重写，我们写成虚函数
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
