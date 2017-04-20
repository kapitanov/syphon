﻿using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Serilog.Events;
using Syphon.Configuration;
using Syphon.Parsing;
using Syphon.Processing;

namespace Syphon
{
    internal static class PresetFactory
    {
        public static IPreset Create(Preset id)
        {
            switch (id)
            {
                case Preset.CaptainRu: return new CaptainRuPreset();
                case Preset.DefaultEn: return new DefaultEnPreset();
                case Preset.FaggotRu: return new FaggotRuPreset();
                case Preset.JointRu: return new JointRuPreset();
                case Preset.LiteratureRu: return new LiteratureRuPreset();
                case Preset.LudvigRu: return new LudvigRuPreset();
                case Preset.PetrovichRu: return new PetrovichRuPreset();
                case Preset.SailorRu: return new SailorRuPreset();
                case Preset.TestAi: return new TestAiPreset();

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
