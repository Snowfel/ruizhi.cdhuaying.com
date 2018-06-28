<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="NodeID"/>
    <xsl:param name="TagID"/>
    <xsl:output method="html" version="1.0" encoding="utf-8" indent="no"/>
    <xsl:template match="/">
        <xsl:choose>
            <xsl:when test="NewDataSet/Table">
                <div>
                    <xsl:attribute name="class">carousel-inner
                    </xsl:attribute>
                    <xsl:for-each select="NewDataSet/Table">
                        <div>
                            <xsl:attribute name="class">carousel-item
                                <xsl:if test="position() = 1">active</xsl:if>
                            </xsl:attribute>
                            <xsl:attribute name="style">
                                background:url(<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>)
                                <xsl:value-of select="bgColor"/> center 0 no-repeat;
                            </xsl:attribute>
                            <a>
                                <xsl:attribute name="href">
                                    <xsl:value-of select="RedirectLink"/>
                                </xsl:attribute>
                                <xsl:attribute name="target">_blank</xsl:attribute>
                            </a>
                        </div>
                    </xsl:for-each>
                </div>
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
        </xsl:choose>

        <div class="container">
            <xsl:attribute name="class">container
            </xsl:attribute>
            <xsl:choose>
                <xsl:when test="NewDataSet/Table">
                    <ol>
                        <xsl:attribute name="class">carousel-indicators
                        </xsl:attribute>
                        <xsl:for-each select="NewDataSet/Table">
                            <li>
                                <xsl:attribute name="data-target">#<xsl:value-of select="$TagID"/>-{pe.position()}
                                </xsl:attribute>
                                <xsl:attribute name="data-slide-to">0
                                </xsl:attribute>
                                <xsl:if test="position() = 1">
                                    <xsl:attribute name="class">
                                        active
                                    </xsl:attribute>
                                </xsl:if>
                            </li>
                        </xsl:for-each>
                    </ol>
                </xsl:when>
                <xsl:otherwise>
                </xsl:otherwise>
            </xsl:choose>

            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>

        </div>

    </xsl:template>
</xsl:stylesheet>