namespace COMP7211Assignment2
{
    //by Min 30003457
    internal class CourseCardCreator
    {
        //variables or objects
        private readonly CourseDetector cd;
        private readonly CourseCards ccList;
        private readonly CourseCard cc;
        private readonly int courseCount;
        private int col = 0;
        private readonly int maxCols = 2;
        private int totalCount = 0;

        public CourseCardCreator(int id)
        {
            cd = new CourseDetector(id);
            ccList = new CourseCards();
            cc = new CourseCard(); //creates the two columns from constructor
            courseCount = cd.DetectedCourses.Count;

            CreateAll();
        }
        public void CreateAll()
        {
            for (int i = 0; i < CalculateRows(); i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    //detect left or right on column
                    if (col == 0)
                    {
                        AddCourseCard();
                        col++;
                    }
                    else
                    {
                        AddCourseCard();
                        AddRowToCourseList();
                        col = 0;
                    }

                    //end method if end of course list
                    if (totalCount == courseCount)
                    {
                        return;
                    }

                    totalCount++;
                }
            }

            totalCount = 0; //reset
        }

        private void AddRowToCourseList()
        {
            ccList.courseCards.Add(cc);
        }

        private void AddCourseCard()
        {
            //cc.rowGrid.Children.Add(cc.CreateLayout(col, cd.DetectedCourses[totalCount].ID.ToString(), cd.DetectedCourses[totalCount].Name));
        }

        private int CalculateRows()
        {
            if ((courseCount % 2) < 0)
            {
                return (courseCount / 2) + 1;
            }
            else
            {
                return courseCount / 2;
            }
        }
    }
}
