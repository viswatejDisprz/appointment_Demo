        public async Task<ValueResult<string>> GetSkillDescriptionSuggestionAsync(SkillAISuggestionRequest request)
        {
            request.Validate<SkillAISuggestionRequest, SkillAISuggestionRequestValidator>();
            
            var description = await _skillSuggestionAI.GetSkillDescriptionSuggestionAsync(request);
            return new ValueResult<string>
            {
                value = description
            };
        }

        public async Task<ValueResult<string>> GetSkillDetailedDescriptionSuggestionAsync(SkillAISuggestionRequest request)
        {
            request.Validate<SkillAISuggestionRequest, SkillAISuggestionRequestValidator>();
            
            var description = await _skillSuggestionAI.GetSkillDetailedDescriptionSuggestionAsync(request);
            return new ValueResult<string>
            {
                value = description
            };
        }

        public async Task<List<SkillProficiencyLevelSuggestion>> GetSkillProficiencyLevelsSuggestionAsync(SkillAISuggestionRequest request)
        {
            request.Validate<SkillAISuggestionRequest, SkillAISuggestionRequestValidator>();
            
            var proficiencyLevels = await _skillSuggestionAI.GetSkillProficiencyLevelsSuggestionAsync(request);
            return proficiencyLevels.Select(item => item.ToSADto()).ToList();
        }

        public async Task<List<BaseEncyclopedia>> GetSkillWikiTagsSuggestionAsync(SkillAISuggestionRequest request)
        {
            request.Validate<SkillAISuggestionRequest, SkillAISuggestionRequestValidator>();
            
            var wikis = await _skillSuggestionAI.GetSkillWikiTagsSuggestionAsync(request);
            var existingWikis = (await _encyclopediaDAL.GetWikipediasAsync(wikis)).ToDictionary(key => key.encyclopedia, value => value);
            return wikis.Select(wikiName =>
            {
                if(existingWikis.TryGetValue(wikiName, out var wiki))
                    return wiki;
                wiki = new BaseEncyclopedia { encyclopedia = wikiName };
                wiki.url = wiki.GetUrl();
                return wiki;
            }).ToList();
        }