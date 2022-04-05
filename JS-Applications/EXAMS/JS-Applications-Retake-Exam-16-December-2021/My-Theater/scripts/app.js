import page from "../node_modules/page/page.mjs";

import { homeView } from "./views/home.js";
import { navigationView } from "./views/navigation.js";
import {loginView} from "./views/login.js";
import { registerView } from "./views/register.js";
import { createTheaterView } from "./views/createTheater.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { profileView } from "./views/profile.js";

page(navigationView);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page("/create", createTheaterView);
page("/theaters/:id", detailsView);
page("/edit/:id", editView);
page('/profile', profileView);

page.start();