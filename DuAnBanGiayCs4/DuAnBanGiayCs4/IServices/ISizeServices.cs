﻿using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface ISizeServices
    {
        public bool CreateSize(Size sz);
        public bool UpdateSize(Size sz);
        public bool DeleteSize(Guid id);
        public List<Size> GetAllSize();
        public Size GetSizeById(Guid id);
        public List<Size> GetSizeByName(int name);
    }
}
