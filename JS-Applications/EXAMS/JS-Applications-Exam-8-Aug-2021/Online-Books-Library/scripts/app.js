import page from '../node_modules/page/page.mjs';
import { nagivationView } from './views/navigationView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { dashboardView } from './views/dashboardView.js';
import { addBookView } from './views/addBookView.js';
import {bookDetailsView} from './views/bookDetailsView.js';
import { editView } from './views/editView.js';
import { myBooksView } from './views/myBooksView.js';

page(nagivationView);
page('/', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/dashboard', dashboardView);
page('/addBook', addBookView);
page('/books/:bookId', bookDetailsView );
page('/edit/:id', editView);
page('/MyBooks', myBooksView);

page.start();