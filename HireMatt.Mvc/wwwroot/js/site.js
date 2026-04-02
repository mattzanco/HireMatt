// Shared UI: focus rings on buttons, optional card fade-in (respects reduced motion)
(function () {
    document.addEventListener('DOMContentLoaded', function () {
        document.querySelectorAll('.btn').forEach(function (btn) {
            btn.addEventListener('mouseup', function () { this.blur(); });
            btn.addEventListener('mouseleave', function () { this.blur(); });
        });

        var businessCard = document.querySelector('.business-card');
        var reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
        if (businessCard && !reduceMotion) {
            businessCard.style.opacity = '0';
            businessCard.style.transition = 'opacity 0.7s ease';
            requestAnimationFrame(function () {
                setTimeout(function () {
                    businessCard.style.opacity = '1';
                }, 50);
            });
        }
    });
})();
