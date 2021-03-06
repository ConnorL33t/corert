// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

using Internal.NativeFormat;

using Debug = System.Diagnostics.Debug;

namespace Internal.TypeSystem
{
    public class UniversalCanonLayoutAlgorithm : FieldLayoutAlgorithm
    {
        public static UniversalCanonLayoutAlgorithm Instance = new UniversalCanonLayoutAlgorithm();

        private UniversalCanonLayoutAlgorithm() { }

        public override bool ComputeContainsGCPointers(DefType type)
        {
            // This should never be called
            throw new NotSupportedException();
        }

        public override DefType ComputeHomogeneousFloatAggregateElementType(DefType type)
        {
            return null;
        }

        public override ComputedInstanceFieldLayout ComputeInstanceLayout(DefType type, InstanceLayoutKind layoutKind)
        {
            return new ComputedInstanceFieldLayout()
            {
                FieldSize = LayoutInt.Indeterminate,
                FieldAlignment = LayoutInt.Indeterminate,
                ByteCountUnaligned = LayoutInt.Indeterminate,
                ByteCountAlignment = LayoutInt.Indeterminate,
                Offsets = Array.Empty<FieldAndOffset>()
            };
        }

        public override ComputedStaticFieldLayout ComputeStaticFieldLayout(DefType type, StaticLayoutKind layoutKind)
        {
            return new ComputedStaticFieldLayout()
            {
                NonGcStatics = new StaticsBlock() { Size = LayoutInt.Zero, LargestAlignment = LayoutInt.Zero },
                GcStatics = new StaticsBlock() { Size = LayoutInt.Zero, LargestAlignment = LayoutInt.Zero },
                ThreadStatics = new StaticsBlock() { Size = LayoutInt.Zero, LargestAlignment = LayoutInt.Zero },
                Offsets = Array.Empty<FieldAndOffset>()
            };
        }

        public override ValueTypeShapeCharacteristics ComputeValueTypeShapeCharacteristics(DefType type)
        {
            return ValueTypeShapeCharacteristics.None;
        }
    }
}
