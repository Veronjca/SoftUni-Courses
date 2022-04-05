import page from '../node_modules/page/page.mjs';

import { catalogueView } from './views/catalogue.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { navbarView } from './views/navbar.js';
import { registerView } from './views/register.js';

page(navbarView);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/catalogue', catalogueView);
page('/games/:gameId', detailsView);
page('/edit/:gameId', editView);

page.start();