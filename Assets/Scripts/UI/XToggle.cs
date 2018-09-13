using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UI
{
    public class XToggle : MonoBehaviour
    {
        public delegate void ChangeHandler(bool isOn);
        private List<ChangeHandler> _delegates = new List<ChangeHandler>();

        private ChangeHandler _realOnChanged;

		public Image _optImage = null;
        [SerializeField]
        private UnityEngine.UI.Toggle _toggle = null;
        [SerializeField]
		private Color _colorOn;
        [SerializeField]
		private Color _colorOff;

        private bool _isOn;

        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                _isOn = value;
                _toggle.isOn = _isOn;
                onChange(_isOn);
            }
        }

		public Sprite SpriteBackground
		{
			set
			{
				_optImage.sprite = value;
			}
		}

        public event ChangeHandler OnChange
        {
            add
            {
                _realOnChanged += value;
                _delegates.Add(value);
            }

            remove
            {
                _realOnChanged -= value;
                _delegates.Remove(value);
            }
        }

        public Color Color
        {
            set
            {
                if (_optImage != null)
                {
                    _optImage.color = value;
                }
            }
        }

        public void Awake()
        {
            if (_toggle == null)
                throw new System.NullReferenceException();

            _toggle.onValueChanged.AddListener(onChange);
            _isOn = _toggle.isOn;
            setColor();
        }

        public void RemoveAllListeners()
        {
            for (int i = 0, c = _delegates.Count; i < c; ++i)
            {
                var d = _delegates[i];
                _realOnChanged -= d;
            }
            _delegates.Clear();
        }

		public void SetInitValue(bool isOn)
		{
			_isOn = isOn;
			setColor();
			if (_realOnChanged != null) _realOnChanged(_isOn);
		}

        private void setValue(bool isOn)
        {
            _toggle.isOn = isOn;
        }

        private void onChange(bool isOn)
        {
            _isOn = isOn;
            setColor();
            if (_realOnChanged != null) _realOnChanged(_isOn);
//            AudioPlayer.Instance.PlaySound(C.DefaultConfig.SoundButtonClickDefault);
        }

        private void setColor()
        {
            if (_isOn)
            {
				_optImage.color = _colorOn;
            }
            else
            {
				_optImage.color = _colorOff;
            }
        }
    }
}
