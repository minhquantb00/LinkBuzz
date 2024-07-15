<script>
import Rightbar from "@/components/right-bar.vue"

export default {
    name: "LOGIN",
    components: {
        Rightbar
    }
}
</script>

<template>
    <div class="auth-main v1">
        <div class="auth-wrapper">
            <div class="auth-form">
                <div class="error-card">
                    <div class="card-body">
                        <div class="error-image-block">
                            <img class="img-fluid" src="@/assets/images/pages/img-under-maintenance.png" alt="img">
                        </div>
                        <div class="text-center">
                            <h1 class="mt-2">Under construction</h1>
                            <p class="mt-2 mb-4 text-muted f-20">We couldn’t find the page you were looking for. Why not try
                                back to the Homepage.</p>
                            <router-link class="btn btn-primary d-inline-flex align-items-center mb-3"
                                to="/dashboard"><i class="ph-duotone ph-house me-2"></i> Back to Home</router-link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Rightbar />
</template>