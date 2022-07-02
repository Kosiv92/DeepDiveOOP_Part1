using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    /// <summary>
    /// Права доступа
    /// </summary>
    public struct FieldAccessRightments
    {
        public readonly bool IsVisible;

        public readonly bool IsEditable;

        /// <summary>
        /// Публичный конструктор прав доступа для поля
        /// </summary>
        /// <param name="visible">Возможность просмотра</param>
        /// <param name="editable">Возможность редактирования</param>
        public FieldAccessRightments(bool visible, bool editable)
        {
            IsVisible = visible;

            IsEditable = editable;
        }
    }
}
