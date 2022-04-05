import page from "../node_modules/page/page.mjs"

import { allMemesView } from "./views/allMemes.js";
import { createMemeView } from "./views/createMeme.js";
import { editView } from "./views/edit.js";
import { homeView } from "./views/home.js";
import { loginView } from "./views/login.js";
import { memeDetailsView } from "./views/memeDetails.js";
import { navigationView } from "./views/navigation.js"
import { profileView } from "./views/profile.js";
import { registerView } from "./views/register.js";

page(navigationView);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createMemeView);
page('/all', allMemesView);
page("/memes/:memeId", memeDetailsView);
page("/edit/:memeId", editView);
page("/profile", profileView);

page.start();