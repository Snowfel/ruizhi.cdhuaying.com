<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="NodeID"/>
    <xsl:param name="tagid"/>
    <xsl:output method="html" version="1.0" encoding="utf-8" indent="no"/>
    <xsl:template match="/">
        <xsl:choose>
            <xsl:when test="NewDataSet/Table">
                <div>
                    <xsl:attribute name="class">carousel-inner</xsl:attribute>
                    <xsl:for-each select="NewDataSet/Table">
                        <div>
                            <xsl:attribute name="class">carousel-item<xsl:if test="position() = 1"> active</xsl:if></xsl:attribute>
                            <xsl:attribute name="style">background:url(<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>)<xsl:value-of select="bgColor"/> center 0 no-repeat;</xsl:attribute>
                            <a>
                                <xsl:attribute name="href"><xsl:value-of select="RedirectLink"/></xsl:attribute>
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
            <xsl:attribute name="class">container</xsl:attribute>
            <xsl:choose>
                <xsl:when test="NewDataSet/Table">
                    <ol>
                        <xsl:attribute name="class">carousel-indicators</xsl:attribute>
                        <xsl:for-each select="NewDataSet/Table">
                            <li>
                                <xsl:attribute name="data-target">#<xsl:value-of select="$tagid"/></xsl:attribute>
                                <xsl:attribute name="data-slide-to"><xsl:value-of select="position() - 1"/></xsl:attribute>
                                <xsl:if test="position() = 1">
                                    <xsl:attribute name="class">active</xsl:attribute>
                                </xsl:if>
                            </li>
                        </xsl:for-each>
                    </ol>
                </xsl:when>
                <xsl:otherwise>
                </xsl:otherwise>
            </xsl:choose>

            <a>
                <xsl:attribute name="class">carousel-control-prev</xsl:attribute>
                <xsl:attribute name="href">#<xsl:value-of select="$tagid"/></xsl:attribute>
                <xsl:attribute name="role">button</xsl:attribute>
                <xsl:attribute name="data-slide">prev</xsl:attribute>
                <span>
                    <xsl:attribute name="class">carousel-control-prev-icon</xsl:attribute>
                    <xsl:attribute name="aria-hidden">true</xsl:attribute>
                </span>
                <span>
                    <xsl:attribute name="class">sr-only</xsl:attribute>
                    Previous
                </span>
            </a>
            <a>
                <xsl:attribute name="class">carousel-control-next</xsl:attribute>
                <xsl:attribute name="href">#<xsl:value-of select="$tagid"/></xsl:attribute>
                <xsl:attribute name="role">button</xsl:attribute>
                <xsl:attribute name="data-slide">next</xsl:attribute>
                <span>
                    <xsl:attribute name="class">carousel-control-next-icon</xsl:attribute>
                    <xsl:attribute name="aria-hidden">true</xsl:attribute>
                </span>
                <span>
                    <xsl:attribute name="class">sr-only</xsl:attribute>
                    Next
                </span>
            </a>
        </div>
    </xsl:template>
</xsl:stylesheet>