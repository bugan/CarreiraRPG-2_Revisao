// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InputMaster.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputMaster : InputActionAssetReference
{
    public InputMaster()
    {
    }
    public InputMaster(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Jill
        m_Jill = asset.GetActionMap("Jill");
        m_Jill_Andar = m_Jill.GetAction("Andar");
        m_Jill_Atacar = m_Jill.GetAction("Atacar");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Jill = null;
        m_Jill_Andar = null;
        m_Jill_Atacar = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Jill
    private InputActionMap m_Jill;
    private InputAction m_Jill_Andar;
    private InputAction m_Jill_Atacar;
    public struct JillActions
    {
        private InputMaster m_Wrapper;
        public JillActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Andar { get { return m_Wrapper.m_Jill_Andar; } }
        public InputAction @Atacar { get { return m_Wrapper.m_Jill_Atacar; } }
        public InputActionMap Get() { return m_Wrapper.m_Jill; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(JillActions set) { return set.Get(); }
    }
    public JillActions @Jill
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new JillActions(this);
        }
    }
}
