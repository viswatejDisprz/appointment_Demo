/// <summary>
        /// Get short skill description suggested by AI
        /// </summary>
        [IsUserHasAccessToAPI(new UserTypes[] { UserTypes.SuperUser, UserTypes.SME, UserTypes.SkillingArchitect, UserTypes.Viewer })]
        [HttpPost, Route("skillsArchitect/v3/skills/suggestion/description")]
        [ProducesResponseType(typeof(ValueResult<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<DisprzError>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DisprzError), (int)HttpStatusCode.InternalServerError)]
        public async Task<ValueResult<string>> GetSkillDescriptionSuggestionAsync([FromBody]SkillAISuggestionRequest request)
        {
            return await _skillBAL.GetSkillDescriptionSuggestionAsync(request);
        }

        /// <summary>
        /// Get detailed skill description suggested by AI
        /// </summary>
        [IsUserHasAccessToAPI(new UserTypes[] { UserTypes.SuperUser, UserTypes.SME, UserTypes.SkillingArchitect, UserTypes.Viewer })]
        [HttpPost, Route("skillsArchitect/v3/skills/suggestion/detailed-description")]
        [ProducesResponseType(typeof(ValueResult<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<DisprzError>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DisprzError), (int)HttpStatusCode.InternalServerError)]
        public async Task<ValueResult<string>> GetSkillDetailedDescriptionSuggestionAsync([FromBody]SkillAISuggestionRequest request)
        {
            return await _skillBAL.GetSkillDetailedDescriptionSuggestionAsync(request);
        }

        /// <summary>
        /// Get Skill Proficiency Levels with description and knowledge suggested by AI
        /// </summary>
        [IsUserHasAccessToAPI(new UserTypes[] { UserTypes.SuperUser, UserTypes.SME, UserTypes.SkillingArchitect, UserTypes.Viewer })]
        [HttpPost, Route("skillsArchitect/v3/skills/suggestion/proficiency-levels")]
        [ProducesResponseType(typeof(List<SkillProficiencyLevelSuggestion>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<DisprzError>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DisprzError), (int)HttpStatusCode.InternalServerError)]
        public async Task<List<SkillProficiencyLevelSuggestion>> GetSkillProficiencyLevelsSuggestionAsync([FromBody]SkillAISuggestionRequest request)
        {
            return await _skillBAL.GetSkillProficiencyLevelsSuggestionAsync(request);
        }

        /// <summary>
        /// Get skill wiki tags suggested by AI
        /// </summary>
        [IsUserHasAccessToAPI(new UserTypes[] { UserTypes.SuperUser, UserTypes.SME, UserTypes.SkillingArchitect, UserTypes.Viewer })]
        [HttpPost, Route("skillsArchitect/v3/skills/suggestion/wikis")]
        [ProducesResponseType(typeof(List<BaseEncyclopedia>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<DisprzError>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DisprzError), (int)HttpStatusCode.InternalServerError)]
        public async Task<List<BaseEncyclopedia>> GetSkillWikiTagsSuggestionAsync([FromBody]SkillAISuggestionRequest request)
        {
            return await _skillBAL.GetSkillWikiTagsSuggestionAsync(request);
        }