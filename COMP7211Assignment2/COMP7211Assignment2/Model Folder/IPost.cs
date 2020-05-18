﻿using System;

namespace COMP7211Assignment2.Model_Folder
{
    interface IPost
    {
        string Content { get; set; }
        int Downvotes { get; set; }
        int Id { get; set; }
        DateTime Time { get; set; }
        int Upvotes { get; set; }
    }
}