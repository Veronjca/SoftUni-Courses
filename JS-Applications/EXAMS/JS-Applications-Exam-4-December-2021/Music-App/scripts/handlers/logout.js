import {logoutUser} from './musicAppService.js';
import page from '../../node_modules/page/page.mjs';

export const logoutHandler = () => {
    logoutUser();
    sessionStorage.clear();
    page.redirect('/');
  };