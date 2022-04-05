import page from "../node_modules/page/page.mjs";

import { catalogView } from "./views/catalog.js";
import { loginView } from "./views/login.js";
import { navigationView } from "./views/navigation.js";
import { registerView } from "./views/register.js";
import { homeView } from "./views/home.js";
import { createAlbumView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { searchView } from "./views/search.js";

page(navigationView);
page("/", homeView);
page("/login", loginView);
page("/register", registerView);
page("/catalog", catalogView);
page("/create", createAlbumView);
page("/albums/:albumId", detailsView);
page("/edit/:albumId", editView);
page('/search', searchView);

page.start();
