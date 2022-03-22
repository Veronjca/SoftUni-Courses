import page from '../node_modules/page/page.mjs';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { dashboardView } from './views/dashboardView.js';
import { registerView } from './views/registerView.js';
import { createView } from './views/createView.js';
import {detailsView} from './views/detailsView.js';

page('/', homeView);
page('/home', homeView);
page('/login', loginView);
page('/register', registerView);
page('/dashboard', dashboardView);
page('/create', createView);
page('/ideas/:ideaId', detailsView);

page.start();