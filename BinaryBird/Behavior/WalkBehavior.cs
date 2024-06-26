﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using BinaryBird.Data;

namespace BinaryBird.Behavior
{
    public class WalkBehavior : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public WalkBehavior()
          : base("WalkBehavior", "WB",
              "Set how people walk",
              "BinaryNature", "BinaryBird")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Seperate Coefficient", "SC", "I don't want to fly along with others", GH_ParamAccess.item);
            pManager.AddNumberParameter("Cohesion Coefficient", "CC", "Lets go together!", GH_ParamAccess.item);
            pManager.AddNumberParameter("Alignment Coefficient", "AC", "Are we heading to same way?", GH_ParamAccess.item);
            pManager.AddNumberParameter("Max Slope", "MS", "Maximum Slope that Human can Handle", GH_ParamAccess.item);
            pManager.AddNumberParameter("Max Speed", "MxS", "Maximum Speed of Human", GH_ParamAccess.item);
            pManager.AddNumberParameter("Min Speed", "MnS", "Manimum Speed of Human", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("WalkBehavior", "WB", "How people will walk", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            #region ///Set Parameter
            double f_seperate = new double();
            double f_cohesion = new double();
            double f_align = new double();
            double max_slope = new double();
            double max_speed = new double();
            double min_speed = new double();

            if (!DA.GetData(0, ref f_seperate)) { return; }
            if (!DA.GetData(1, ref f_cohesion)) { return; }
            if (!DA.GetData(2, ref f_align)) { return; }
            if (!DA.GetData(3, ref max_slope)) { return; }
            if (!DA.GetData(4, ref max_speed)) { return; }
            if (!DA.GetData(5, ref min_speed)) { return; } 
            #endregion

            WalkData WalkBehavior = new WalkData(f_seperate, f_cohesion, f_align, max_slope, max_speed, min_speed);

            DA.SetData(0, WalkBehavior);

        }
            /// <summary>
            /// Provides an Icon for the component.
            /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("57044F16-7C6A-460A-AE0E-AA64AA6FD56A"); }
        }
    }
}