using LimsUI.Models;
using System;

namespace LimsUI.GraphQL.SampleClasses
{
    public class SamplePayload
    {
        public Sample Sample { get; set; }

        public SamplePayload(Sample sample)
        {
            Sample = sample;
        }
    }
}
