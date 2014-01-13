﻿using NRaas.CommonSpace.Helpers;
using NRaas.CommonSpace.Options;
using NRaas.DresserSpace.Tasks;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.DresserSpace.Options.Sims.Remove
{
    public class RemoveCurrentMakeup : OperationSettingOption<Sim>, IRemoveOption
    {
        public override string GetTitlePrefix()
        {
            return "RemoveCurrentMakeup";
        }

        protected override bool Allow(GameHitParameters<Sim> parameters)
        {
            if (!parameters.mTarget.IsHuman) return false;

            return base.Allow(parameters);
        }

        protected override OptionResult Run(GameHitParameters<Sim> parameters)
        {
            if (!AcceptCancelDialog.Show(Common.Localize(GetTitlePrefix() + ":Prompt", parameters.mTarget.IsFemale, new object[] { parameters.mTarget })))
            {
                return OptionResult.Failure;
            }

            RemovePartsOutfitTask.Perform(parameters.mTarget, CASParts.sMakeup, true, null);

            return OptionResult.SuccessRetain;
        }
    }
}