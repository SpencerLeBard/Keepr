import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../pages/Home.vue";
// @ts-ignore
import ProfilePage from "../pages/ProfilePage.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profile/:name",
    name: "Profile",
    component: ProfilePage,
  }
];

const router = new VueRouter({
  routes,
});

export default router;
