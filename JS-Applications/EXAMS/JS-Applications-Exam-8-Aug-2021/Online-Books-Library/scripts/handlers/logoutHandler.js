import {logoutUser} from './requestHandler.js';
import page from '../../node_modules/page/page.mjs';

export const logoutHandler = async () => {
    await logoutUser();
    sessionStorage.clear();
    page.redirect('/dashboard');
  };