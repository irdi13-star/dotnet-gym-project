
public class ServicesPage(IPage page)
{
    private readonly IPage _page = page;

    public ILocator ServicesLinkDesktop => _page.Locator("#servicesLinkDesktop");
    public ILocator OurServicesTitle => _page.Locator("#ourServicesTitle");
    public ILocator PersonalTrainingCard => _page.Locator("#personalTrainingCard");
    public ILocator MeetOurTeamOverlay => _page.Locator("#meetOurTeam");
    public ILocator PersonalTrainingCardTitle => _page.Locator("#personalTrainingTitle");
    public ILocator GroupProgramsCard => _page.Locator("#groupProgramsCard");
    public ILocator SignUpForFreeOverlay => _page.Locator("#signUpForFree");
    public ILocator GroupProgramsCardTitle => _page.Locator("#groupProgramsTitle");
    public ILocator NutritionCoachingCard => _page.Locator("#nutritionCoachingCard");
    public ILocator CreateYourDietOverlay => _page.Locator("#createYourDiet");
    public ILocator NutritionCoachingCardTitle => _page.Locator("#nutritionCoachingTitle");

    // -------- PERSONAL TRAINING PAGE --------
    public ILocator PersonalTrainingHeader => _page.Locator("#personalTrainingHeader");
    public ILocator PersonalTrainingTitle => _page.Locator("#personalTrainingTitle");
    public ILocator PersonalTrainingSubtitle => _page.Locator("#personalTrainingSubtitle");
    public ILocator PersonalTrainingInfo => _page.Locator("#personalTrainingInfo");
    public ILocator PersonalTrainingImage => _page.Locator("#personalTrainingImage");
    public ILocator PersonalTrainingDescription => _page.Locator("#personalTrainingDescription");
    public ILocator PersonalTrainingWhatTitle => _page.Locator("#personalTrainingWhatTitle");
    public ILocator PersonalTrainingWhatText => _page.Locator("#personalTrainingWhatText");
    public ILocator PersonalTrainingBenefits => _page.Locator("#personalTrainingBenefits");
    public ILocator PersonalTrainingBenefitsTitle => _page.Locator("#personalTrainingBenefitsTitle");
    public ILocator PersonalTrainingBenefitsList => _page.Locator("#personalTrainingBenefitsList li");
    public ILocator PersonalTrainingContact => _page.Locator("#personalTrainingContact");
    public ILocator PersonalTrainingContactText => _page.Locator("#personalTrainingContactText");
    public ILocator PersonalTrainingContactButton => _page.Locator("#personalTrainingContactButton");

    // -------- GROUP Programs
    public ILocator GroupProgramsHeader => _page.Locator("#groupProgramsHeader");
    public ILocator GroupProgramsTitle => _page.Locator("#groupProgramsTitle");
    public ILocator GroupProgramsSubtitle => _page.Locator("#groupProgramsSubtitle");
    public ILocator GroupProgramsInfo => _page.Locator("#groupProgramsInfo");
    public ILocator GroupProgramsBenefits => _page.Locator("#groupProgramsBenefits");
    public ILocator GroupProgramsBenefitsTitle => _page.Locator("#groupProgramsBenefitsTitle");
    public ILocator GroupProgramsImage => _page.Locator("#groupProgramsImage");
    public ILocator GroupProgramsDescription => _page.Locator("#groupProgramsDescription");
    public ILocator GroupProgramsWhatTitle => _page.Locator("#groupProgramsWhatTitle");
    public ILocator GroupProgramsWhatText => _page.Locator("#groupProgramsWhatText");
    public ILocator GroupProgramsBenefitsList => _page.Locator("#groupProgramsBenefitsList li");
    public ILocator GroupProgramsContact => _page.Locator("#groupProgramsContact");
    public ILocator GroupProgramsContactText => _page.Locator("#groupProgramsContactText");
    public ILocator GroupProgramsContactButton => _page.Locator("#groupProgramsContactButton");

    // -------- NUTRITION Coaching
    public ILocator NutritionCoachingHeader => _page.Locator("#nutritionCoachingHeader");
    public ILocator NutritionCoachingTitle => _page.Locator("#nutritionCoachingTitle");
    public ILocator NutritionCoachingSubtitle => _page.Locator("#nutritionCoachingSubtitle");
    public ILocator NutritionCoachingInfo => _page.Locator("#nutritionCoachingInfo");
    public ILocator NutritionCoachingImage => _page.Locator("#nutritionCoachingImage");
    public ILocator NutritionCoachingDescription => _page.Locator("#nutritionCoachingDescription");
    public ILocator NutritionCoachingWhatTitle => _page.Locator("#nutritionCoachingWhatTitle");
    public ILocator NutritionCoachingWhatText => _page.Locator("#nutritionCoachingWhatText");
    public ILocator NutritionCoachingBenefits => _page.Locator("#nutritionCoachingBenefits");
    public ILocator NutritionCoachingBenefitsTitle => _page.Locator("#nutritionCoachingBenefitsTitle");
    public ILocator NutritionCoachingBenefitsList => _page.Locator("#nutritionCoachingBenefitsList li");
    public ILocator NutritionCoachingContact => _page.Locator("#nutritionCoachingContact");
    public ILocator NutritionCoachingContactText => _page.Locator("#nutritionCoachingContactText");
    public ILocator NutritionCoachingContactButton => _page.Locator("#nutritionCoachingContactButton");
}