<?xml version="1.0" encoding="utf-8"?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="nodeId" />
    <xsl:param name="currentId" />
    <xsl:output method="html" />
    <xsl:template match="/">

        <xsl:for-each select="/NewDataSet/Table">
            <li>
                <xsl:attribute name="class">nav-item
                    <xsl:if test="NodeID = $currentId">class_on</xsl:if>
                </xsl:attribute>
                <a>

                    <xsl:attribute name="class">nav-link <xsl:if test="NodeID = $currentId">active</xsl:if></xsl:attribute>
                    <xsl:attribute name="id">pills-home-tab</xsl:attribute>
                    <xsl:attribute name="data-toggle">pill</xsl:attribute>
                    <xsl:attribute name="href">tab</xsl:attribute>
                    <xsl:attribute name="role">#pills-home</xsl:attribute>
                    <xsl:attribute name="aria-controls">pills-home</xsl:attribute>
                    <xsl:attribute name="aria-selected">true</xsl:attribute>
                    <xsl:value-of select="NodeName"/>
                </a>
            </li>
        </xsl:for-each>
    </xsl:template>
</xsl:transform>
