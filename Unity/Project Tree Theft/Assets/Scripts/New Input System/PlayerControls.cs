// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/New Input System/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""5f95a272-254c-46fd-8888-32df7a1753c3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a687545e-007d-4f81-811d-a2a514ed51a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attach"",
                    ""type"": ""Button"",
                    ""id"": ""cb54e104-e4a7-4cd8-8642-94e6f1e6b95c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Chop"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f4dcfc9b-9721-4637-be7c-49f414e44613"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""PassThrough"",
                    ""id"": ""37c4cc0f-5304-4d3b-983c-91cae06a64dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""ee16d69b-0fb9-4a81-ac4c-3296548e5361"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef56c1b8-aaee-4559-9a70-71298bfba3eb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0770a3e1-2239-4731-8421-4c5722b2c1b1"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f76546bf-7543-407c-8ceb-932bca6aa231"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Chop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84108ba9-ea7a-42bc-8231-8e89d1ee2cb8"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Chop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2845e5a-1009-4e3c-8711-587993d04dc3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""809874fe-8843-4439-ae8e-72ac65784eb3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e64e9d40-deb1-4719-aac7-f40c7a218a16"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d7f44d6b-e9b8-44b5-a585-2f60c03651a2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44161708-a9ae-4f5b-8b65-ac7b43be3a44"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6b7256b3-53b5-440e-a38d-228a9bfe2573"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e2cfba0f-c9ff-4e49-b4ae-f3734039c3b3"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d04d80d-0691-4de2-8647-a76baa72a42d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""7124c7a2-ef60-423c-bbc1-b4feb2742190"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c85a61e6-9db0-46ec-93d8-5b9894e5d3dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attach"",
                    ""type"": ""Button"",
                    ""id"": ""ce7b2617-e5d3-43d3-9a6f-eb0686317cc9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Chop"",
                    ""type"": ""PassThrough"",
                    ""id"": ""350875e5-a978-4b22-a388-0bb13c7db616"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""PassThrough"",
                    ""id"": ""91b7f429-0422-4f15-8105-d01388662b7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""889576ff-0fc5-457b-98e8-39c733787b2e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""328be7f6-9a24-48c2-907b-1bf9319bdb98"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0c40880-c1ae-44fd-8810-2b3df68d4d7a"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f786243d-89e4-4b13-b534-9537fbe090b8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Chop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1968aeee-b55a-42c2-981d-30d1fe40cbd9"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Chop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9474a7a3-28d8-49c9-a7d3-7d32e823e8cd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c1a7b817-6013-4a43-8ba0-579e7a9c7837"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d6a84ad8-534f-4737-bb0a-a47e21dbc35c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""affe292b-36c6-41a1-86af-60d98cb37377"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cf50dd63-7463-41a0-932f-dd0b238dbafd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87e23b7b-2b60-478d-937e-85eb2ed38302"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc3c5f7d-d641-4a1f-9cfe-dae526132562"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ba577b6-df54-437e-80fe-14932e511d17"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15facb7d-373c-4428-a9b5-dbde3addf51c"",
                    ""path"": ""<Keyboard>/end"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""18afca3d-f196-427e-9bd9-eaf0a1578805"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""6c0acf17-c075-49df-b3da-ace65fa67384"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce78b8f9-473b-467a-b2c3-abf505d5b153"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""P1Menu"",
            ""id"": ""34414e70-0ac4-4769-8c94-01e8daed5a1a"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""a332d825-6d58-41a1-98d4-3891724e3d74"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""bb632b90-3e88-4394-b908-8ac127254820"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f4499deb-3cba-46ed-834e-bc54e76f5bf6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcabd0dd-2cb2-4351-b708-ec68130d1202"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""P2Menu"",
            ""id"": ""3d137db5-41bf-43a8-a779-e9c529fcc0c4"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""edf5ea2c-f1f8-480a-89bc-1874ad6e13a6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""70ae21fc-45a3-4b77-9005-1f18bc4e205b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""705053fa-1923-4f27-868f-283b8400f149"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17eb1605-9097-43c7-8dfd-34a42e401fae"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Key&Mouse"",
            ""bindingGroup"": ""Key&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_Attach = m_Player1.FindAction("Attach", throwIfNotFound: true);
        m_Player1_Chop = m_Player1.FindAction("Chop", throwIfNotFound: true);
        m_Player1_Charge = m_Player1.FindAction("Charge", throwIfNotFound: true);
        m_Player1_Rotate = m_Player1.FindAction("Rotate", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        m_Player2_Attach = m_Player2.FindAction("Attach", throwIfNotFound: true);
        m_Player2_Chop = m_Player2.FindAction("Chop", throwIfNotFound: true);
        m_Player2_Charge = m_Player2.FindAction("Charge", throwIfNotFound: true);
        m_Player2_Rotate = m_Player2.FindAction("Rotate", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Newaction = m_Menus.FindAction("New action", throwIfNotFound: true);
        // P1Menu
        m_P1Menu = asset.FindActionMap("P1Menu", throwIfNotFound: true);
        m_P1Menu_Left = m_P1Menu.FindAction("Left", throwIfNotFound: true);
        m_P1Menu_Right = m_P1Menu.FindAction("Right", throwIfNotFound: true);
        // P2Menu
        m_P2Menu = asset.FindActionMap("P2Menu", throwIfNotFound: true);
        m_P2Menu_Left = m_P2Menu.FindAction("Left", throwIfNotFound: true);
        m_P2Menu_Right = m_P2Menu.FindAction("Right", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Attach;
    private readonly InputAction m_Player1_Chop;
    private readonly InputAction m_Player1_Charge;
    private readonly InputAction m_Player1_Rotate;
    public struct Player1Actions
    {
        private @PlayerControls m_Wrapper;
        public Player1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Attach => m_Wrapper.m_Player1_Attach;
        public InputAction @Chop => m_Wrapper.m_Player1_Chop;
        public InputAction @Charge => m_Wrapper.m_Player1_Charge;
        public InputAction @Rotate => m_Wrapper.m_Player1_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Attach.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttach;
                @Attach.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttach;
                @Attach.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttach;
                @Chop.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnChop;
                @Chop.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnChop;
                @Chop.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnChop;
                @Charge.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCharge;
                @Rotate.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attach.started += instance.OnAttach;
                @Attach.performed += instance.OnAttach;
                @Attach.canceled += instance.OnAttach;
                @Chop.started += instance.OnChop;
                @Chop.performed += instance.OnChop;
                @Chop.canceled += instance.OnChop;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_Attach;
    private readonly InputAction m_Player2_Chop;
    private readonly InputAction m_Player2_Charge;
    private readonly InputAction m_Player2_Rotate;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @Attach => m_Wrapper.m_Player2_Attach;
        public InputAction @Chop => m_Wrapper.m_Player2_Chop;
        public InputAction @Charge => m_Wrapper.m_Player2_Charge;
        public InputAction @Rotate => m_Wrapper.m_Player2_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Attach.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttach;
                @Attach.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttach;
                @Attach.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttach;
                @Chop.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnChop;
                @Chop.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnChop;
                @Chop.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnChop;
                @Charge.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCharge;
                @Rotate.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attach.started += instance.OnAttach;
                @Attach.performed += instance.OnAttach;
                @Attach.canceled += instance.OnAttach;
                @Chop.started += instance.OnChop;
                @Chop.performed += instance.OnChop;
                @Chop.canceled += instance.OnChop;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_Newaction;
    public struct MenusActions
    {
        private @PlayerControls m_Wrapper;
        public MenusActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menus_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);

    // P1Menu
    private readonly InputActionMap m_P1Menu;
    private IP1MenuActions m_P1MenuActionsCallbackInterface;
    private readonly InputAction m_P1Menu_Left;
    private readonly InputAction m_P1Menu_Right;
    public struct P1MenuActions
    {
        private @PlayerControls m_Wrapper;
        public P1MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_P1Menu_Left;
        public InputAction @Right => m_Wrapper.m_P1Menu_Right;
        public InputActionMap Get() { return m_Wrapper.m_P1Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P1MenuActions set) { return set.Get(); }
        public void SetCallbacks(IP1MenuActions instance)
        {
            if (m_Wrapper.m_P1MenuActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_P1MenuActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_P1MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public P1MenuActions @P1Menu => new P1MenuActions(this);

    // P2Menu
    private readonly InputActionMap m_P2Menu;
    private IP2MenuActions m_P2MenuActionsCallbackInterface;
    private readonly InputAction m_P2Menu_Left;
    private readonly InputAction m_P2Menu_Right;
    public struct P2MenuActions
    {
        private @PlayerControls m_Wrapper;
        public P2MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_P2Menu_Left;
        public InputAction @Right => m_Wrapper.m_P2Menu_Right;
        public InputActionMap Get() { return m_Wrapper.m_P2Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P2MenuActions set) { return set.Get(); }
        public void SetCallbacks(IP2MenuActions instance)
        {
            if (m_Wrapper.m_P2MenuActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_P2MenuActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_P2MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public P2MenuActions @P2Menu => new P2MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyMouseSchemeIndex = -1;
    public InputControlScheme KeyMouseScheme
    {
        get
        {
            if (m_KeyMouseSchemeIndex == -1) m_KeyMouseSchemeIndex = asset.FindControlSchemeIndex("Key&Mouse");
            return asset.controlSchemes[m_KeyMouseSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttach(InputAction.CallbackContext context);
        void OnChop(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttach(InputAction.CallbackContext context);
        void OnChop(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IP1MenuActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
    public interface IP2MenuActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
