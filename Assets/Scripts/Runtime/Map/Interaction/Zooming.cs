using Game.Runtime.Management;

namespace Game.Runtime.Map.Interaction
{
    public class Zooming : AbsMapFeatures
    {
        public System.Action OnZoomIn;
        public System.Action OnZoomOut;

        private float m_Step;
        private float m_worldCameraOrthographicSize;

        private GlobalSettings.MenuOptions.MapSettings _mapSettings;

        public override void Initialize()
        {
            base.Initialize();

            _mapSettings = GlobalReferences.Map.MapSettings;
            updateWorldCameraOrthographicSize();
        }

        public override void Execute()
        {
            if (isMouseScrollWhellMovingIn() && canCameraZoomIn())
            {
                calculateStep();
                stepIn();

                OnZoomIn?.Invoke();
                updateWorldCameraOrthographicSize();
            }

            if (isMouseScrollWhellMovingOut() && canCameraZoomOut())
            {
                calculateStep();
                stepOut();

                OnZoomOut?.Invoke();
                updateWorldCameraOrthographicSize();
            }
        }

        private void updateWorldCameraOrthographicSize()
        {
            m_worldCameraOrthographicSize = _worldCamera.orthographicSize;
        }

        private bool canCameraZoomIn()
        {
            return m_worldCameraOrthographicSize > _mapSettings.ZoomLimitMin;
        }

        private bool canCameraZoomOut()
        {
            return m_worldCameraOrthographicSize < _mapSettings.ZoomLimitMax;
        }

        private bool isMouseScrollWhellMovingIn()
        {
            return _mouseControler.isMouseScrollWhellMovingIn();
        }

        private bool isMouseScrollWhellMovingOut()
        {
            return _mouseControler.isMouseScrollWhellMovingOut();
        }

        private void calculateStep()
        {
            m_Step = 0.1f * _mapSettings.ZoomSpeed;
        }

        private void stepIn()
        {
            _worldCamera.orthographicSize -= m_Step;
        }

        private void stepOut()
        {
            _worldCamera.orthographicSize += m_Step;
        }
    }
}