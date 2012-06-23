using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShivasTower.Model.Objects;

using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Model.Map
{
    class Room
    {   
        public Location Location 
        { 
            get; 
            set; 
        }

        public int NumOfLocks
        {
            get;
            set;
        }

        public bool IsLocked
        {
            get
            {
                return NumOfLocks > 0;
            }
        }

        private bool blnPassable;
        public bool Passable
        {
            get
            {
                return blnPassable & !IsLocked;
            }
            set
            {
                blnPassable = value;
            }
        }

        #region Text Properties

        public string NewMovementText
        {
            private get;
            set;
        }

        protected virtual string DefaultMovementText
        {
            get
            {
                return "Moving...";
            }
        }

        protected virtual string NewDefaultMovementText
        {
            get
            {
                return null;
            }
        }

        private string strMovementText;
        public string MovementText
        {
            get
            {
                if (UseNewText)
                {
                    if (string.IsNullOrEmpty(NewMovementText))
                    {
                        if (string.IsNullOrEmpty(NewDefaultMovementText))
                        {
                            return DefaultMovementText;
                        }
                        else
                        {
                            return NewDefaultMovementText;
                        }
                    }
                    else
                    {
                        return NewMovementText;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMovementText))
                    {
                        return DefaultMovementText;
                    }
                    else
                    {
                        return strMovementText;
                    }
                }
            }
            set
            {
                strMovementText = value;
            }
        }

        public string NewExamineText
        {
            private get;
            set;
        }

        protected virtual string DefaultExamineText
        {
            get
            {
                return "You see nothing of interest.";
            }
        }

        protected virtual string NewDefaultExamineText
        {
            get
            {
                return null;
            }
        }

        private string strExamineText;
        public string ExamineText
        {
            get
            {
                if (UseNewText)
                {
                    if (string.IsNullOrEmpty(NewExamineText))
                    {
                        if (string.IsNullOrEmpty(NewDefaultExamineText))
                        {
                            return DefaultExamineText;
                        }
                        else
                        {
                            return NewDefaultExamineText;
                        }
                    }
                    else
                    {
                        return NewExamineText;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strExamineText))
                    {
                        return DefaultExamineText;
                    }
                    else
                    {
                        return strExamineText;
                    }
                }
            }
            set
            {
                strExamineText = value;
            }
        }

        public string NewActionText
        {
            private get;
            set;
        }

        protected virtual string DefaultActionText
        {
            get
            {
                return "There is nothing to interact with in this room.";
            }
        }

        protected virtual string NewDefaultActionText
        {
            get
            {
                return null;
            }
        }

        private string strActionText;
        public string ActionText
        {
            get
            {
                if (UseNewText)
                {
                    if (string.IsNullOrEmpty(NewActionText))
                    {
                        if (string.IsNullOrEmpty(NewDefaultActionText))
                        {
                            return DefaultActionText;
                        }
                        else
                        {
                            return NewDefaultActionText;
                        }
                    }
                    else
                    {
                        return NewActionText;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strActionText))
                    {
                        return DefaultActionText;
                    }
                    else
                    {
                        return strActionText;
                    }
                }
            }
            set
            {
                strActionText = value;
            }
        }

        #endregion Text Properties

        public ESpecial Special;

        protected virtual bool UseNewText
        {
            get
            {
                return false;
            }
        }

        public virtual void PerformAction()
        {
        }
    }
}