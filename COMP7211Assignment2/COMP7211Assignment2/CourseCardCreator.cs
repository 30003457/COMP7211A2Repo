using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace COMP7211Assignment2
{
    //by Min 30003457
    class CourseCardCreator
    {
        //variables or objects
        CourseDetector cd;
        CourseCards ccList;
        CourseCard cc;
        int courseCount;
        int col = 0, maxCols = 2, totalCount = 0; //maxCols for scalability

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
            cc.rowGrid.Children.Add(cc.CreateLayout(col, cd.DetectedCourses[totalCount].ID, cd.DetectedCourses[totalCount].Name));
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
