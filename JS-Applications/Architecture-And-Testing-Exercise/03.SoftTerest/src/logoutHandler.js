import * as requestHandler from "./requestHandler.js";
import page from '../node_modules/page/page.mjs';

export const logoutHandler = async () => {
    await requestHandler.logoutUser();
    sessionStorage.clear();
    page.redirect('/home');
  };
