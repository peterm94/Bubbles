using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components.Camera
{
    public class GoodFollowCam : RenderableComponent, IUpdatable
    {
        private readonly Entity _target;
        private readonly Entity _cursor;
        private Nez.Camera _camera;

        [Inspectable] private bool _follow;
        private Vector2 _midSize;

        private Vector2 _startLerpPos;
        private Vector2 _targetPos;
        private float _currLerpTime;
        private float _totalLerpTime = 2f;

        public GoodFollowCam(Entity target, Entity cursor)
        {
            _target = target;
            _cursor = cursor;
        }

        public void update()
        {
            if (_target != null)
            {
                _targetPos = (_target.position - _cursor.position);
                _targetPos.Normalize();
                _targetPos = _target.position - (_targetPos * 20f);

                _camera.position = Vector2.Lerp(_camera.position, _targetPos, 0.05f);
//                FancyLerp();
            }
        }

        public override void onAddedToEntity()
        {
            _camera = entity.getComponent<Nez.Camera>();
            _midSize = new Vector2(_camera.bounds.width, _camera.bounds.height) * 0.5f;
        }

        public override RectangleF bounds { get; } = RectangleF.maxRect;

        public override void render(Nez.Graphics graphics, Nez.Camera camera)
        {
            if (Core.debugRenderEnabled)
            {
                graphics.batcher.drawCircle(camera.screenToWorldPoint(_midSize), 10f, Color.Beige);
                graphics.batcher.drawCircle(_targetPos, 10f, Color.Orchid);

                graphics.batcher.drawCircle(_targetPos, 10f, Color.Green);
            }
        }

        // im not ready yet
        private void FancyLerp()
        {
            if (!_follow)
            {
                _follow = true;

                _startLerpPos = _camera.position;
                _currLerpTime = 0f;
            }

            if (_follow)
            {
                _currLerpTime += Time.deltaTime;
                if (_currLerpTime > _totalLerpTime)
                {
                    _currLerpTime = _totalLerpTime;
                    _follow = false;
                    Console.WriteLine("Stop");
                }

                var lerpAmt = _currLerpTime / _totalLerpTime;

                // sexy curve
                lerpAmt = lerpAmt * lerpAmt * (3f - 2f * lerpAmt);

                _camera.position = Vector2.Lerp(_startLerpPos, _targetPos, lerpAmt);
            }
        }
    }
}
