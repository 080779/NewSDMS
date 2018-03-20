using SDMS.DTO.DTO;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Common
{
    public class ViewFind
    {
        /*
        private int _ParentID;
        private int _Location;
        public ViewFind(int _ParentID)
        {
            this._ParentID = _ParentID;
        }
        public ViewFind(int _ParentID, int _Location)
        {
            this._ParentID = _ParentID;
            this._Location = _Location;


        }
        public bool FindNode(UserDTO view)
        {
            if (view.ParentID == this._ParentID && view.Location == this._Location)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Find(UserDTO view)
        {
            if (view.ParentID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindID(UserDTO view)
        {
            if (view.ID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class RowView : List<UserDTO>
    {
        public RowView() { }
        public bool Exist(int key)
        {
            UserDTO view = this.Find(new ViewFind(key).Find);
            if (view == default(UserDTO))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Exist(int ParentID, int Location, out int UserID)
        {
            UserDTO view = this.Find(new ViewFind(ParentID, Location).FindNode);
            if (view == default(UserDTO))
            {
                UserID = 0;
                return false;
            }
            else
            {

                UserID = Convert.ToInt32(view.ID);
                return true;
            }
        }
        public UserDTO GetModel(int key)
        {
            UserDTO view = this.Find(new ViewFind(key).FindID);
            if (view == default(UserDTO))
            {
                return null;
            }
            else
            {
                return view;
            }
        }
    }


    public class BnetViewFind
    {
        private int _ParentID;
        private int _Location;
        public BnetViewFind(int _ParentID)
        {
            this._ParentID = _ParentID;
        }
        public BnetViewFind(int _ParentID, int _Location)
        {
            this._ParentID = _ParentID;
            this._Location = _Location;


        }
        public bool FindNode(UserDTO view)
        {
            if (view.ID == this._ParentID && view.Location == this._Location)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool BnetFind(UserDTO view)
        {
            if (view.ID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool BnetFindID(UserDTO view)
        {
            if (view.ID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class RowBnetView : List<UserDTO>
    {
        public RowBnetView() { }
        public bool Exist(int key)
        {
            UserDTO view = this.Find(new BnetViewFind(key).BnetFindID);
            if (view == default(UserDTO))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Exist(int ParentID, int Location, out int ID)
        {
            UserDTO view = this.Find(new BnetViewFind(ParentID, Location).FindNode);
            if (view == default(UserDTO))
            {
                ID = 0;
                return false;
            }
            else
            {

                ID = Convert.ToInt32(view.ID);
                return true;
            }
        }
        public UserDTO GetModel(int key)
        {
            UserDTO view = this.Find(new BnetViewFind(key).BnetFindID);
            if (view == default(UserDTO))
            {
                return null;
            }
            else
            {
                return view;
            }
        }
        */
    }
}