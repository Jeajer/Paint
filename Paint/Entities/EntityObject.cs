using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Entities
{
    public abstract class EntityObject : ICloneable
    {
        private readonly EntityType type;
        protected bool isVisible;
        protected bool selected;

        public EntityObject(EntityType type)
        {
            this.type = type;
            this.isVisible = true;
            this.selected = false;
        }

        public EntityType Type
        {
            get { return type; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public bool Selected
        {
            get { return selected; }
            set { this.selected = value; }
        }

        public bool IsSelected
        {
            get { return selected; }
        }

        public void Select()
        {
            this.Selected = true;
        }

        public void DeSelect()
        {
            this.Selected = false;
        }

        public abstract object CopyOrMove(Vector3 fromPoint, Vector3 toPoint);

        public abstract object Rotate2D(Vector3 basePoint, Vector3 targetPoint);

        public abstract object Mirror2D(Vector3 basePoint, Vector3 targetPoint);

        public abstract object Clone();
    }
}
