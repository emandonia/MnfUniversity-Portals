<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="events.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.events.events" %>


<!DOCTYPE html>


    <div class="wrapper">

        <ul id="sb-slider" class="sb-slider">
            <li>
                <a href="../../Styles/University_Master/images/events/1.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/1.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Creative Lifesaver</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/2.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/2.png" alt="image2" /></a>
                <div class="sb-description">
                    <h3>Honest Entertainer</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/3.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/3.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Brave Astronaut</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/4.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/4.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Affectionate Decision Maker</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/5.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/5.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Affectionate Decision Maker</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/6.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/6.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Affectionate Decision Maker</h3>
                </div>
            </li>
            <li>
                <a href="../../Styles/University_Master/images/events/7.png" target="_blank">
                    <img src="../../Styles/University_Master/images/events/7.png" alt="image1" /></a>
                <div class="sb-description">
                    <h3>Affectionate Decision Maker</h3>
                </div>
            </li>


        </ul>

        <div id="shadow" class="shadow"></div>

        <div id="nav-arrows" class="nav-arrows">
            <a href="#">Next</a>
            <a href="#">Previous</a>
        </div>

        <div id="nav-dots" class="nav-dots">
            <span class="nav-dot-current"></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
        </div>

    </div>
    <!-- /wrapper -->




<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
<script src="../Styles/University_Master/jquery/jquery.slicebox.js"></script>
<script type="text/javascript">
    $(function () {

        var Page = (function () {

            var $navArrows = $('#nav-arrows').hide(),
                $navDots = $('#nav-dots').hide(),
                $nav = $navDots.children('span'),
                $shadow = $('#shadow').hide(),
                slicebox = $('#sb-slider').slicebox({
                    onReady: function () {

                        $navArrows.show();
                        $navDots.show();
                        $shadow.show();

                    },
                    onBeforeChange: function (pos) {

                        $nav.removeClass('nav-dot-current');
                        $nav.eq(pos).addClass('nav-dot-current');

                    }
                }),

                init = function () {

                    initEvents();

                },
                initEvents = function () {

                    // add navigation events
                    $navArrows.children(':first').on('click', function () {

                        slicebox.next();
                        return false;

                    });

                    $navArrows.children(':last').on('click', function () {

                        slicebox.previous();
                        return false;

                    });

                    $nav.each(function (i) {

                        $(this).on('click', function (event) {

                            var $dot = $(this);

                            if (!slicebox.isActive()) {

                                $nav.removeClass('nav-dot-current');
                                $dot.addClass('nav-dot-current');

                            }

                            slicebox.jump(i + 1);
                            return false;

                        });

                    });

                };

            return { init: init };

        })();

        Page.init();

    });
		</script>





