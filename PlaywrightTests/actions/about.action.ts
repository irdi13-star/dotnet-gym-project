import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { BrowserContext, Page } from "@playwright/test";
import AboutPage from "../pages/about.page";
import CommonActions from "./common.actions";

export default class AboutActions extends CommonActions {
  about: AboutPage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.about = new AboutPage(page, context);
  }

  async verifyAboutPageContent() {
    // About Us
    await this.checkH2(strings.aboutPage.aboutUsTitle);
    await this.checkP(strings.aboutPage.aboutUsParagraph);

    // Our Mission
    await this.checkH3(strings.aboutPage.ourMissionTitle);
    await this.checkP(strings.aboutPage.ourMissionParagraph);

    // What We Offer
    await this.checkH3(strings.aboutPage.whatWeOfferTitle);
    await this.checkLi(
      strings.aboutPage.whatWeOffer1Strong +
        " " +
        strings.aboutPage.whatWeOffer1Description
    );
    await this.checkLi(
      strings.aboutPage.whatWeOffer2Strong +
        " " +
        strings.aboutPage.whatWeOffer2Description
    );
    await this.checkLi(
      strings.aboutPage.whatWeOffer3Strong +
        " " +
        strings.aboutPage.whatWeOffer3Description
    );
    await this.checkLi(
      strings.aboutPage.whatWeOffer4Strong +
        " " +
        strings.aboutPage.whatWeOffer4Description
    );

    // Our Values
    await this.checkH3(strings.aboutPage.ourValuesTitle);
    await this.checkLi(
      strings.aboutPage.ourValues1Strong +
        " " +
        strings.aboutPage.ourValues1Description
    );
    await this.checkLi(
      strings.aboutPage.ourValues2Strong +
        " " +
        strings.aboutPage.ourValues2Description
    );
    await this.checkLi(
      strings.aboutPage.ourValues3Strong +
        " " +
        strings.aboutPage.ourValues3Description
    );

    // Meet The Team
    await this.checkH3(strings.aboutPage.meetTheTeamTitle);
    await this.checkP(strings.aboutPage.meetTheTeamParagraph);

    // Join Us Today
    await this.checkH3(strings.aboutPage.joinUsTodayTitle);
    await this.checkP(strings.aboutPage.joinUsTodayParagraph);
  }

  async verifyRegisterLink() {
    await this.checkLinkByTextAndHref(
      strings.aboutPage.registerButton,
      routes.navbarLinks.login
    );
  }
}
