<script>
import Rightbar from "@/components/right-bar.vue"

export default {
    name: "REGISTER",
    components: {
        Rightbar
    }
}
</script>

<template>
    <div class="auth-main v1">
        <div class="auth-wrapper">
            <div class="auth-form">
                <div class="card my-5">
                    <div class="card-body">
                        <div class="text-center">
                            <img src="@/assets/images/authentication/img-auth-register.png" alt="images"
                                class="img-fluid mb-3">
                            <h4 class="f-w-500 mb-1">Đăng ký để trải nghiệm</h4>
                            <p class="mb-3">Bạn đã có tài khoản? <a href="@/pages/login-v1.html"
                                    class="link-primary">Đăng nhập</a></p>
                        </div>
                        <BRow class="row">
                            <BCol class="col-sm-6">
                                <div class="form-group mb-3">
                                    <input type="text" class="form-control" placeholder="First Name">
                                </div>
                            </BCol>
                            <BCol class="col-sm-6">
                                <div class="form-group mb-3">
                                    <input type="text" class="form-control" placeholder="Last Name">
                                </div>
                            </BCol>
                        </BRow>
                        <div class="form-group mb-3">
                            <input type="text" class="form-control" placeholder="Tài khoản">
                        </div>
                        <div class="form-group mb-3">
                            <input type="email" class="form-control" placeholder="Email">
                        </div>
                        <div class="form-group mb-3">
                            <input type="number" class="form-control" placeholder="Số điện thoại">
                        </div>
                        <div class="form-group mb-3">
                            <input type="password" class="form-control" placeholder="Mật khẩu">
                        </div>
                        <div class="form-group mb-3">
                            <input type="password" class="form-control" placeholder="Xác nhận mật khẩu">
                        </div>
                        <div class="d-flex mt-1 justify-content-between">
                            <div class="form-check">
                                <input class="form-check-input input-primary" type="checkbox" id="customCheckc1" checked="">
                                <label class="form-check-label text-muted" for="customCheckc1">Tôi đồng ý với các chính sách & điều khoản </label>
                            </div>
                        </div>
                        <div class="d-grid mt-4">
                            <button type="button" class="btn btn-primary">Đăng ký</button>
                        </div>
                        <div class="saprator my-3">
                            <span>Hoặc</span>
                        </div>
                        <div class="text-center">
                            <ul class="list-inline mx-auto mt-3 mb-0">
                                <li class="list-inline-item">
                                    <a href="https://www.facebook.com/" class="avtar avtar-s rounded-circle bg-facebook"
                                        target="_blank">
                                        <i class="fab fa-facebook-f text-white"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a href="https://twitter.com/" class="avtar avtar-s rounded-circle bg-twitter"
                                        target="_blank">
                                        <i class="fab fa-twitter text-white"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a href="https://myaccount.google.com/"
                                        class="avtar avtar-s rounded-circle bg-googleplus" target="_blank">
                                        <i class="fab fa-google text-white"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <Rightbar />
</template>