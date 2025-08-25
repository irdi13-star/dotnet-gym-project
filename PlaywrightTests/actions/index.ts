import { BrowserContext, Page } from "@playwright/test";
import BaseActions from "./base.actions";
import NavigationActions from "./navigation.actions";
import HomeActions from "./home.actions";
import CommonActions from "./common.actions";
import navbarFooterActions from "./navbarFooter.actions";
import AboutActions from "./about.action";
import ServicesActions from "./services.action";
import AuthActions from "./auth.actions";

export default class App {
  base: BaseActions;
  navigation: NavigationActions;
  common: CommonActions;
  home: HomeActions;
  navbarFooter: navbarFooterActions;
  about: AboutActions;
  services: ServicesActions;
  auth: AuthActions;

  constructor(page: Page, context: BrowserContext) {
    this.base = new BaseActions(page, context);
    this.navigation = new NavigationActions(page, context);
    this.common = new CommonActions(page, context);
    this.home = new HomeActions(page, context);
    this.navbarFooter = new navbarFooterActions(page, context);
    this.about = new AboutActions(page, context);
    this.services = new ServicesActions(page, context);
    this.auth = new AuthActions(page, context);
  }
}
